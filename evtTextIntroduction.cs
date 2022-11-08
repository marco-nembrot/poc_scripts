using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class evtTextIntroduction : CustomEvent {
	public Color onEnterColor = Color.green;
	public Color onExitColor = Color.white;
    public int onEnterFontSize = 50;
    public int onExitFontSize = 70;

    private string component;
	private Vector3 cameraInitialPosition;
	private GameObject cameraObject;



	// Use this for initialization
	new void Start () {
		component = "";
        cameraInitialPosition = new Vector3(2.7f, -1.4f, -5.8f);

		if (!staticBehaviour.planeIntroDone) {
			component = staticBehaviour.planeIntro;
			staticBehaviour.planeIntro = "";
			staticBehaviour.planeIntroDone = true;
		}

		cameraObject = GameObject.Find("World/Camera");
		cameraObject.transform.position = cameraInitialPosition;

        base.Start();
	}
	// Update is called once per frame
	void Update () {
		if (component != "") {
			foreach (Transform child in GameObject.Find("Presentation").transform) {
				child.gameObject.SetActive(false);
			}
			if (component.Equals("Informations")) {
                print(cameraObject.transform.position);
				showPlan("Plan_Informations");
				cameraObject.transform.position = new Vector3(2.7f, -8.3f, -5.8f);
                print(cameraObject.transform.position);
            }
			if (component.Equals("Parametres") || component.Equals("retourParametres")) {
				showPlan("Plan_Parametres");
				cameraObject.transform.position = new Vector3(-8.4f, -1.4f, -5.8f);
			}
			if (component.Equals("Jouer") || component.Equals("retourJeu")) {
				showPlan("Plan_Jeu");
				cameraObject.transform.position = new Vector3(13.7f, -1.4f, -5.8f);
			}
			if (component.Equals("Credits")) {
				showPlan("Plan_Credits");
				GameObject.Find("World").GetComponent<AudioSource>().Stop();
				cameraObject.transform.position = new Vector3(2.7f, -15.0f, -5.8f);
			}
			if (component.Equals("Copyright")) {
				showPlan("Plan_Copyright");
				cameraObject.transform.position = new Vector3(2.7f, -22.0f, -5.8f);
			}
			if (component.Equals("Tutorial")) {
				showPlan("Plan_Tutorial");
				cameraObject.transform.position = new Vector3(13.8f, 5.7f, -5.8f);
			}

//*/ 
    // Desactivating actions 
			if (component.Equals("Main Game")|| component.Equals("retourMain")) {
				showPlan("Plan_Partie-Principale");
				cameraObject.transform.position = new Vector3(24.8f, -1.4f, -5.8f);
			}
			if (component.Equals("Spiritualite") || component.Equals("retourSpiritualite")) {
				showPlan("Plan_Partie-Spiritualite");
				cameraObject.transform.position = new Vector3(35.9f, -1.4f, -5.8f);
			}
			if (component.Equals("Lieux") || component.Equals("retourLieux")) {
				showPlan("Plan_Partie-Lieux");
				cameraObject.transform.position = new Vector3(47f, -1.4f, -5.8f);
			}
			if (component.Equals("Personnes") || component.Equals("retourPersonnes")) {
				showPlan("Plan_Partie-Personnes");
				cameraObject.transform.position = new Vector3(58.1f, -1.4f, -5.8f);
			}
			if (component.Equals("Bonus") || component.Equals("retourBonus")) {
				showPlan("Plan_Bonus");
				cameraObject.transform.position = new Vector3(13.8f, -8.3f, -5.8f);
			}
			if (component.Equals("Bonus_1")) {
				showPlan("Plan_Boss");
				cameraObject.transform.position = new Vector3(13.8f, -15.3f, -5.8f);
			}
//*/
			if (component.Equals("Results")) {
				showPlan("Plan_Results");
				cameraObject.transform.position = new Vector3(13.8f, 12.5f, -5.8f);
			}
			if (component.Equals("retourIntro")) {
				showPlan("Plan_Introduction");
				cameraObject.transform.position = cameraInitialPosition;
				if (!GameObject.Find("World").GetComponent<AudioSource>().isPlaying && staticBehaviour.playSound) {
					GameObject.Find("World").GetComponent<AudioSource>().Play();
				}
			}
			component = "";
		} 
	}
	
	
	
	void showPlan(string name) {
		GameObject.Find("Presentation").transform.Find(name).gameObject.SetActive(true);
	}


    public void callPlan(string name, bool update=true)
    {
        if (update)
        {
            component = name;
            Update();
        }
    }



    public override void OnPointerEnterDelegate(PointerEventData data)
    {
		if (GetComponent<Text>()) {
			GetComponent<Text>().color = onEnterColor;
			GetComponent<Text>().fontSize = onEnterFontSize;
        }
        if (GetComponent<AudioSource>() && staticBehaviour.playEffects) {
			GetComponent<AudioSource>().Play();
		}
    }
    public override void OnPointerExitDelegate(PointerEventData data)
    {
		if (GetComponent<Text>()) {
			GetComponent<Text>().color = onExitColor;
			GetComponent<Text>().fontSize = onExitFontSize;
		}
    }
    public override void OnPointerDownDelegate(PointerEventData data)
    {
		component = this.name;

        print(component);
        //print (cameraObject.transform.position);
    }
	
	
	
	void OnEnable() {
		if (GetComponent<Text>()) {
			GetComponent<Text>().color = onExitColor;
			GetComponent<Text>().fontSize = onExitFontSize;
		}
	}
}