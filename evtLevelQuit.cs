using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class evtLevelQuit : MonoBehaviour {	
	public string plane;
	private bool off;
	private int windowWidth;
	
	public GUISkin skin;

	
	
	void Awake() {}
	// Use this for initialization
	void Start () {
		off = false;
		windowWidth = 400;
	}
	// Update is called once per frame
	void Update () {
		if (staticControls.isQuitButtonDown()) {
			off = true;
			staticBehaviour.Pause(true);
		}

	}
	
	
	
	void OnGUI() {
		if (off) {
			GUI.skin = skin;
			GUI.Window (1, new Rect((Screen.width/2) - 150, 150, windowWidth, 250), showQuit, "Abandonner la partie");
		}
	}
	void showQuit(int windowId) {
		GUI.color = Color.black;
		GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();
				GUILayout.Space(20);
				LabelAndText("Adandon :", "Quitter la partie ?");
				if (Button("Quitter la partie")) {
					staticBehaviour.Pause(false, false);
					staticBehaviour.planeIntro = plane;
					SceneManager.LoadScene("Introduction");
				}
				GUILayout.Space(10);
				LabelAndText("", "Recommencer le niveau ?");
				if (Button("Recommencer")) {
					off = false;
					staticBehaviour.Pause(false, false);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
				GUILayout.Space(40);
				LabelAndText("", "Continuer ?");
				if (Button("Annuler et fermer la fenêtre")) {
					off = false;
					staticBehaviour.Pause(false);
				}
			GUILayout.EndVertical();
		GUILayout.EndHorizontal();
	}
	void LabelAndText(string label, string texte) {
		GUILayout.BeginHorizontal();
		GUILayout.Label(label, GUILayout.MaxWidth(150));
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
		off = true;
		staticBehaviour.Pause(true);
	}
}
