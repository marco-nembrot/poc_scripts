using UnityEngine;
using System.Collections;



public class evtLevelInformations : MonoBehaviour {
	private bool off;
	private int windowWidth;

	public GUISkin skin;
	
	
	
	void Awake() {}
	// Use this for initialization
	void Start () {
		off = false;
		windowWidth = 500;
	}
	// Update is called once per frame
	void Update () {
		if (staticControls.isInformationsButtonDown()) {
			off = !off;
			staticBehaviour.Pause(off);
		}
	}
	
	
	
	void OnGUI() {
		if (off) {
			GUI.skin = skin;
			GUI.Window (1, new Rect((Screen.width/2) - 200, 100, windowWidth, 320), showInformations, "Contrôles");
		}
	}
	void showInformations(int windowId) {
		GUI.color = Color.black;
		GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();
				GUILayout.Space(20);
				LabelAndText("Déplacements :", "Touches directionnelles");
				LabelAndText("Saut :", "Flèche directionnelle Haut");
				LabelAndText("Double-saut :", "<Saut> pendant un saut");
				LabelAndText("Utilisation d'une croix verte :", "X");
				LabelAndText("Prière rapide :", "F");
				LabelAndText("Prière contre les idées noires :", "F + V");
				LabelAndText("Intercession des âmes du purgatoire :", "F + B");
				LabelAndText("Intercession céleste pour ton personnage :", "F + N");
				LabelAndText("Mise en pause :", "P");
				GUILayout.Space(20);
				if (Button("Fermer la fenêtre")) {
					off = false;
					staticBehaviour.Pause(false);
				}
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
	}
	void LabelAndText(string label, string texte) {
		GUILayout.BeginHorizontal();
		GUILayout.Label(label, GUILayout.MaxWidth(250));
		GUILayout.Space(20);
		GUILayout.Label(texte);
		GUILayout.EndHorizontal();
	}
	private bool Button(string label) {
		return GUILayout.Button(
			label, 
			GUILayout.MinHeight(20), 
			GUILayout.MaxWidth(windowWidth)
		);
	}
	


	void OnMouseDown() {
		if (!off) {
			off = true;
			staticBehaviour.Pause(true);
		}
	}
}
