using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;



public class evtParametersGui : MonoBehaviour {
	private string musicButton;
	private string effectsButton;


	
	void OnEnable() {
		GameObject.Find("Identifiant/userId").GetComponent<Text>().text = staticBehaviour.userEmail;
	}
	// Update is called once per frame
	void Update () {
		if (staticBehaviour.playSound) {
			musicButton = "Musique ON";
		} else {
			musicButton = "Musique OFF";
		}
		if (staticBehaviour.playEffects) {
			effectsButton = "Bruitages ON";
		} else {
			effectsButton = "Bruitages OFF";
		}
	}

	
	
	void OnGUI() {
		GUILayout.BeginVertical();
			GUILayout.Space (200);
			GUILayout.BeginHorizontal();
				GUILayout.Space (550);
				if (staticBehaviour.characterId != "") {
					if (Button("Tester le personnage choisi.", 24, 200)) {
						print (staticBehaviour.characterId);
					}
				}
			GUILayout.EndHorizontal();
			
			if (staticBehaviour.characterId != "") {
				GUILayout.Space (276);
			} else {
				GUILayout.Space (300);
			}

			GUILayout.BeginHorizontal();
				GUILayout.Space (400);
				if (Button(musicButton, 24, 200)) {
					activateBackButton(false);
					staticBehaviour.playSound = !staticBehaviour.playSound;
				}
				GUILayout.Space (50);
				if (Button(effectsButton, 24, 200)) {
					activateBackButton(false);
					staticBehaviour.playEffects = !staticBehaviour.playEffects;
				}
			GUILayout.EndHorizontal();

			if (staticBehaviour.personnage != "") {
				GUILayout.Space(27);
			} else {
				GUILayout.Space(30);
			}
			
			if (staticBehaviour.updateParameters) {
				GUILayout.BeginHorizontal();
					GUILayout.Space(120);
					if (Button("Enregistrer les modifications sur le cloud", 30, 300)) {
						StartCoroutine(updateProfil());
					}
					GUILayout.Space(50);
					if (Button("Enregistrer uniquement pour mon temps de jeu", 30, 320)) {
						activateBackButton(true);
					}
			GUILayout.EndHorizontal();
			}
		GUILayout.EndVertical();
	}
	private bool Button(string label, int h, int w) {
		return GUILayout.Button(
			label, 
			GUILayout.MinHeight(h), 
			GUILayout.MaxWidth(w)
		);
	}
	private void LabelAndTextField(string label, string text) {
		GUILayout.BeginHorizontal();
		GUILayout.Label(label, GUILayout.MaxWidth(150));
		text = GUILayout.TextField(text);
		GUILayout.EndHorizontal();
	}



	private IEnumerator updateProfil() {
		// We should only read the screen after all rendering is complete
		yield return new WaitForEndOfFrame();

		// Create a Web Form
		WWWForm form = new WWWForm();
		form.AddField("action", "parametres");
		form.AddField("connexion", staticBehaviour.userConnexionId);
		form.AddField("reglages", staticBehaviour.knowledge);
		form.AddField("difficulte", staticBehaviour.difficulty);
		form.AddField("personnage", staticBehaviour.characterId);
		form.AddField("plateforme", staticBehaviour.plateforme);
		form.AddField("soundOn", (staticBehaviour.playSound) ? bool.TrueString : bool.FalseString);
		form.AddField("effectsOn", (staticBehaviour.playEffects) ? bool.TrueString : bool.FalseString);

		// Upload to a cgi script
		WWW w = new WWW(staticBehaviour.profilUrl, form);
		yield return w;

		print(">>>>>>>>>> Updating user profile...");
		//Debug.Log(JSONNode.Parse(w.text);

		activateBackButton(true);

		if (!String.IsNullOrEmpty(w.error))
			print(w.error);

	}



	void activateBackButton(bool flag) {
		staticBehaviour.updateParameters = !flag;
		GameObject.Find("Plan_Parametres").transform.Find("retourJeu").gameObject.SetActive(flag);
	}
}
