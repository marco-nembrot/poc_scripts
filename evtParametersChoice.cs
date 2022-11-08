using UnityEngine;
using UnityEngine.UI;



public class evtParametersChoice : MonoBehaviour {
	public bool flagGUI;
	public bool flagCursor;
	public string id;
	public string type;
	public string description;

	public Color onSelection;
	public Color onHover;
	public Color onInit;

	public string text;
	public GUISkin skin;
	public int windowWidth;
	public int windowHeight;

	public Vector3 selectionPosition;

	private bool onGUI;
	private bool isSelected;
	private string parent;
	


	// Use this for initialization
	void Start () {
		onGUI = false;
		isSelected = false;
	}
	void OnEnable() {
		setParameters();
	}
	void setParameters() {
		if (type.Equals("personnage")) {
			parent = "Plan_Personnages";
			isSelected = (id.Equals(staticBehaviour.characterId));
			if (isSelected) {
				staticBehaviour.personnage = description;
			}
		}
		if (type.Equals("plateforme")) {
			parent = "Plan_Plateformes";
			isSelected = (id.Equals(staticBehaviour.plateforme));
			if (isSelected) {
				staticBehaviour.plateformeTexture = GetComponent<Image>();
			}
		}
		if (type.Equals("difficulty")) {
			parent = "Plan_Difficulte";
			description = GetComponent<Text>().text;
			isSelected = (description.Equals(staticBehaviour.difficulty));
			GetComponent<Text>().color = (isSelected) ? onSelection : onInit;
		}
		if (type.Equals("knowledge")) {
			parent = "Plan_Connaissance";
			description = GetComponent<Text>().text;
			isSelected = (description.Equals(staticBehaviour.knowledge));
			GetComponent<Text>().color = (isSelected) ? onSelection : onInit;
		}

		if (flagCursor) {
			if (isSelected) {
				GameObject.Find(parent + "/Selection").GetComponent<Text>().text = description;
				GameObject.Find(parent + "/Selection_Cursor").transform.position = selectionPosition;
			}
		}
	}


	
	void OnGUI() {
		if (onGUI) {
			GUI.skin = skin;
			Vector3 temp = Input.mousePosition;
			GUI.Window (1, new Rect(temp.x - (windowWidth/2), Screen.height - (temp.y + windowHeight + 20), windowWidth, windowHeight), showDetails, id + " : " + description);
		}
	}
	void showDetails(int windowId) {
		GUILayout.BeginHorizontal();
		GUILayout.Label(text);
		GUILayout.EndHorizontal();

	}
	private bool Button(string label) {
		return GUILayout.Button(
			label,
			GUILayout.MinHeight(20),
			GUILayout.MaxWidth(windowWidth)
		);
	}



	void OnMouseEnter() {
		if (flagGUI) {
			onGUI = true;
			if (GetComponent<Text>() != null)
				GetComponent<Text>().color = onHover;
		}
	}
	void OnMouseExit() {
		if (flagGUI) {
			onGUI = false;
			if (GetComponent<Text>() != null)
				GetComponent<Text>().color = (isSelected) ? onSelection : onInit;
		}
	}
	void OnMouseDown() {
		if (type.Equals("personnage")) {
			staticBehaviour.personnage = description;
			staticBehaviour.characterId = id;
		} else if (type.Equals("plateforme")) {
			staticBehaviour.plateforme = id;
			staticBehaviour.plateformeTexture = this.GetComponent<Image>();
		} else if (type.Equals("difficulty")) {
			staticBehaviour.difficulty = description;
		}

		if (flagCursor) {
			GameObject.Find(parent + "/Selection").GetComponent<Text>().text = description;
			GameObject.Find(parent + "/Selection_Cursor").transform.position = selectionPosition;
		} else {
			GameObject.Find(parent).BroadcastMessage("setSelected", this.name);
		}
		
		if (!staticBehaviour.updateParameters) {
			GameObject.Find("Plan_Parametres").BroadcastMessage("activateBackButton", false);
		}
		staticBehaviour.updateParameters = true;
	}
	
	
	
	void setSelected(string name) {
		isSelected = (this.name.Equals(name));
		if (flagGUI) {
			GetComponent<Text>().color = (isSelected) ? onSelection : onInit;
		}
	}
}
