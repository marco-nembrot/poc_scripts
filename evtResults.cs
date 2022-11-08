using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;



public class evtResults : MonoBehaviour {
	public GUISkin skin;
	public GUIStyle textStyle = new GUIStyle();
	private Vector2 scrollPosition;
	private int labelWidth;
	
	private bool[] dataFlag;
	private string[] dataText;
	private string nextLevel;

	private bool isInitialized;
	private bool startRoutine;



	// Use this for initialization
	void Start () {
		labelWidth = 300;
		scrollPosition = Vector2.zero;

		isInitialized = startRoutine = false;
		if (staticBehaviour.isInitialized) {
			int max = evtWorld.letters.Length;
			dataFlag = new bool[max];
			dataText = new string[max];
			for (int c = 0; c < max; c++) {
				dataFlag [c] = false;
				dataText [c] = "Recherche en cours...";
			}
			StartCoroutine (getTextsFromLevel());
		}
	}
	// Update is called once per frame
	void Update () {
		if (!isInitialized && !startRoutine) {
			startRoutine = true;
			StartCoroutine(getTextsFromLevel());
		}
	}
	
	
//*/
	void OnGUI() {
		GUI.skin = skin;
		GUILayout.Window(1, new Rect(80, 80, 820, 450), showResults, staticBehaviour.currentLevel);
	}
//*/
	void showResults(int windowId) {
		GUILayout.BeginVertical();
			scrollPosition = GUILayout.BeginScrollView(scrollPosition);
				GUILayout.Space(20);
				for (int i = 0; i < evtWorld.letters.Length; i++) {
					string texte = "La lettre " + evtWorld.letters[i].ToString();
					if (evtWorld.areLettersCollected[i]) {
						GUI.color = Color.black;
						texte += " a été récoltée.";
					} else {
						GUI.color = Color.gray;
						texte += " n'a pas été récoltée.";
					}
					GUILayout.Label(texte, GUILayout.MaxWidth(labelWidth));
					if (evtWorld.areLettersCollected[i]) {
						GUILayout.BeginHorizontal();
							GUILayout.Space(100);
							GUILayout.Label(dataText[i], GUILayout.MaxWidth(2 * labelWidth));
						GUILayout.EndHorizontal();
					}
				}	
			GUILayout.EndScrollView();
		GUILayout.EndVertical();
	}
	void LabelAndText(string label, string texte) {
		GUILayout.BeginHorizontal();
		GUILayout.Space(300);
		GUILayout.Label(label + " " + texte, GUILayout.MaxWidth(labelWidth));
		GUILayout.EndHorizontal();
		
	}
	void LabelAndText2(string label1, string texte1, string label2, string texte2) {
		GUILayout.BeginHorizontal();
		GUILayout.Space(100);
		GUILayout.Label(label1 + " " + texte1, GUILayout.MaxWidth(labelWidth));
		GUILayout.Space(60);
		GUILayout.Label(label2 + " " + texte2, GUILayout.MaxWidth(labelWidth));
		GUILayout.EndHorizontal();
		
	}
	
	
	
	private IEnumerator getTextsFromLevel() {
		//*
		// We should only read the screen after all rendering is complete
		yield return new WaitForEndOfFrame();
		
		// Create a Web Form
		WWWForm form = new WWWForm();
		form.AddField("action", "paragraphe");
		form.AddField("niveau", staticBehaviour.currentLevel);

		// Upload to a cgi script
		WWW w = new WWW(staticBehaviour.databaseUrl, form);
		yield return w;
		//*
		var results = JSONNode.Parse(w.text);
		print(">>>>>>>>>> Getting texts from current level results...");
		for (int i = 0; i < dataText.Length; i++) {
			dataText[i] = (string) results[i];
		}
		string nextLevel = results["nextLevel"];
		if (nextLevel != null) {
			staticBehaviour.nextLevel = nextLevel;
			GameObject.Find("Plan_Results/nextLevel").SendMessage("Active");
		}
		
		if (!String.IsNullOrEmpty(w.error)) {
			print(w.error);
			isInitialized = true;
			startRoutine = false;
		} else {
			isInitialized = true;
		}
//*/
	}
}
