using UnityEngine;
using System.Collections;



public class evtSouls : MonoBehaviour {
	public string action;
	public GameObject target;

	public bool isMandatory = false;
	public GameObject gourde;
	private bool show;

	private bool onCollider;
	private bool onAction;

	public Color into;

	private GameObject copy;



	// Use this for initialization
	void Start () {
		show = false;
		onAction = false;
		onCollider = false;
	}
	// Update is called once per frame
	void Update () {
		if (!staticBehaviour.isPaused) {
			int price = (int) GameObject.Find("faithBar").GetComponent<evtFaithBar>().getFaithAmount();

			if (staticControls.isFaithButtonDown()) {
				onAction = true;
			} 
			if (staticControls.isFaithButtonUp()) {
				onAction = false;
			}
			if (onCollider && onAction && staticControls.isSoulButtonDown()) {
				if (price == staticBehaviour.faithMaxAmount) {
					print ("Pray united souls !");
					if (action.Equals("destroy")) {
						GameObject.Destroy(target);
					}
					
					staticBehaviour.waterPtConsumed += price;
					evtWorld.scoreLevel += staticBehaviour.scoreUnitedSouls;
					GameObject.Find("faithBar").GetComponent<evtFaithBar>().setFaithAmount(0, false);
					
					if (staticBehaviour.playEffects) {
						GameObject.Find("Bruitages/SoulsAction").GetComponent<AudioSource>().Play();
					}

					staticBehaviour.unitedSouls++;
					GameObject.Destroy(gameObject);
					GameObject.Find("Background").GetComponent<SpriteRenderer>().color = Color.white;
				} else {
					print ("United Souls : not enough faith !");
				}
			}

			if (copy == null) {
				show = false;
			}
			if (isMandatory && onCollider) {
				if (!show && price < staticBehaviour.faithMaxAmount) {
					copy = (GameObject) Instantiate(gourde, gourde.transform.position, gourde.transform.rotation);
					copy.gameObject.SetActive(true);
					show = true;
				}
			}
		}
	}



	void OnTriggerEnter2D(Component collider) {
		if (collider.name.Equals(evtWorld.characterScript.getCharacterName())) {
			show = false;
			onCollider = true;
			GameObject.Find("Background").GetComponent<SpriteRenderer>().color = into;

			if (staticBehaviour.playEffects) {
				GameObject.Find("Bruitages/CollisionSoul").GetComponent<AudioSource>().Play();
			}
		}
	}
	void OnTriggerExit2D() {
		onCollider = false;
		GameObject.Find("Background").GetComponent<SpriteRenderer>().color = Color.white;
	}
}
