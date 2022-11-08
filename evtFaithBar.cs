using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class evtFaithBar : MonoBehaviour {
	// background image that is 256 x 32
	// foreground image that is 256 x 32
	public Texture2D bgImage; 
	public Texture2D fgImage; 
	
	private int x;
	private int y;
	private int width;
	private int height;

	private float faithAmount; 
	private int faithAmountMax;
	private float deltaTime;
	
	public static int minTimeBetweenPrayers = 10;

	private bool action;
	private bool rosario1OnController;
	private bool rosario2OnController;

	

	void Start () {
		width = 256;
		height = 32;
        x = Screen.width - width - 20;
        y = 10;

        deltaTime = Time.time;

		faithAmount = staticBehaviour.faithCurrentAmount;
		faithAmountMax = staticBehaviour.faithMaxAmount;

		action = false;
		rosario1OnController = false;
		rosario2OnController = false;
	}
	void Update () {
		if (!staticBehaviour.isPaused) {
			float diffTime = Time.time - deltaTime;

			if (evtWorld.characterScript.isOnFaith() && diffTime > 3.5f) {
				evtWorld.characterScript.setFaith(false);
				evtWorld.characterScript.getAnimator().SetBool ("Prayer", false);
			}

			if (staticControls.isFaithButtonDown()) {
				action = true;
				if (Mathf.CeilToInt(diffTime) > minTimeBetweenPrayers) {
					faithAmount += evtWorld.characterScript.getFaithValue();
					staticBehaviour.faithCombinedAmount += evtWorld.characterScript.getFaithValue();
					evtWorld.characterScript.setFaith(true);
					evtWorld.characterScript.getAnimator().SetBool ("Prayer", true);
					deltaTime = Time.time;
				}
			}
			if (staticControls.isFaithButtonUp()) {
				action = false;
			}
			
			int price = (int) GameObject.Find("faithBar").GetComponent<evtFaithBar>().faithAmount;
			if (action && staticControls.isIdeaButtonDown()) {
				print ("Fight ideas !");
				bool flag = getRidOfIdeas(staticBehaviour.ideaPerWater);
				if (flag) {
					evtWorld.scoreLevel += staticBehaviour.scoreIdeaOnWater;
				}
			}
			bool rosario = checkRosarioOnController();
			if ( (rosario) || (action && staticControls.isRosarioButtonDown()) ) {
				if (price == staticBehaviour.faithMaxAmount) {
					print ("ROSARIO !!!");
					staticBehaviour.waterPtConsumed += price;
					evtWorld.scoreLevel += staticBehaviour.scoreOnRosario;
					GameObject.Find("FaithBar").GetComponent<evtFaithBar>().faithAmount = 0;
					
					if (staticBehaviour.playEffects) {
						GameObject.Find("Bruitages/Rosario").GetComponent<AudioSource>().Play();
					}
				} else {
					print ("ROSARIO : not enough faith !");
				}
			}

			AdjustValue(0);
			GameObject.Find(this.name + "/value").GetComponent<Text>().text = ((int) faithAmount).ToString() + "/" + faithAmountMax.ToString();
		}
	}


	
	void OnGUI () {
		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup (new Rect (x, y, width, height));
			GUI.Box (new Rect (0, 0, width, height), bgImage);
			// Create a second Group which will be clipped
			// We want to clip the image and not scale it, which is why we need the second Group
			GUI.BeginGroup (new Rect (0, 0, ((float)(faithAmount)/faithAmountMax) * width, height));
				GUI.Box (new Rect (0, 0, width, height), fgImage);
			GUI.EndGroup ();
		GUI.EndGroup ();
	}



	private bool checkRosarioOnController() {
		if (staticControls.isRosarioButton1Down()) {
			rosario1OnController = true;
		}
		if(staticControls.isRosarioButton1Up()) {
			rosario1OnController = false;
		}
		if (staticControls.isRosarioButton2Down()) {
			rosario2OnController = true;
		}
		if(staticControls.isRosarioButton2Up()) {
			rosario2OnController = false;
		}

		bool f1 = rosario1OnController && staticControls.isRosarioButton2Down();
		bool f2 = rosario2OnController && staticControls.isRosarioButton1Down();
		return f1 || f2;
	}



	public static bool getRidOfIdeas(int countIdea) {
		bool flag = false;
		GameObject ideas = GameObject.Find("Ideas");
		if (ideas != null) {
			foreach (Transform child in ideas.transform) {
				if (child.GetComponent<evtGribouillis>().isOnTarget() && countIdea > 0) {
					flag = true;
					countIdea--;
					evtWorld.ideas--;
					staticBehaviour.ideaDestroyed++;
					evtWorld.scoreLevel += staticBehaviour.scoreIdeaDestroyed;
					GameObject.Destroy(GameObject.Find("Ideas/" + child.name));
				}
			}
		}

		return flag;
	}
	public float getFaithAmount() {
		return faithAmount;
	}



	public void setFaithAmount(float value, bool op) {
		if (op) 
			faithAmount += value;
		else
			faithAmount = value;
	}



	private void AdjustValue(int adj) { 
		faithAmount += adj; 
		
		if (faithAmount < 0) 
			faithAmount = 0; 
		
		if (faithAmount > faithAmountMax) 
			faithAmount = faithAmountMax; 
	}
}
