using UnityEngine;
using System;
using System.Collections;



public class evtScreenShot : MonoBehaviour {
	private bool flag;
	private bool save;
	private bool photo;
	private bool concours;
	private int windowWidth;

	public GUISkin skin;
	
	public int selGridInt = 0;
	public string[] selStrings = new string[] {"radio1", "radio2", "radio3"};



	// Use this for initialization
	void Start () {
		save = true;
		flag = false;
		photo = false;
		concours = false;
		windowWidth = 400;
	}
	// Update is called once per frame
	void Update () {}
	
	
	
	void OnGUI() {
		if (flag) {
			GUI.skin = skin;
			GUI.Window (1, new Rect((Screen.width/2) - 200, 100, windowWidth, 240), takeScreenshot, "Imprim-écran");
		}
	}
	void takeScreenshot(int windowId) {
		GUI.color = Color.black;
		GUILayout.BeginHorizontal();
			GUILayout.BeginVertical();
				GUILayout.Space(20);
				if (staticBehaviour.concours) {
					LabelAndText("Concours POC :", staticBehaviour.concoursDate);
					LabelAndText(staticBehaviour.concoursTitle, "");
					concours = GUI.Toggle(new Rect(10, 90, 280, 20), concours, "Participez au concours avec cette photo.");
					save = GUI.Toggle(new Rect(10, 110, 280, 20), save, "Sauvegarder la photo sur le serveur de POC.");
					GUILayout.Space(50);
				} else {
					save = GUI.Toggle(new Rect(10, 50, 280, 20), save, "Sauvegarder la photo sur le serveur de POC.");
					GUILayout.Space(40);
				}

				if (!photo) {
					if (Button("M'envoyer cette photo par mail")) {
						StartCoroutine(UploadPNG());
						photo = true;
					}
				} else {
					LabelAndText("", "Photo envoyée !");
				}
				GUILayout.Space(40);
				if (Button("Fermer la fenêtre")) {
					flag = false;
					save = true;
					photo = false;
					concours = false;
					staticBehaviour.isPauseAllowed = true;
					staticBehaviour.Pause(false, false);
				}
			GUILayout.EndVertical();
		GUILayout.EndHorizontal();
	}
	void LabelAndText(string label, string texte) {
		GUILayout.BeginHorizontal();
			GUILayout.Label(label);
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



	IEnumerator UploadPNG() {
		flag = false;
		staticBehaviour.isPauseAllowed = false;

		// We should only read the screen after all rendering is complete
		yield return new WaitForEndOfFrame();
		
		// Create a texture the size of the screen, RGB24 format
		int width = Screen.width;
		int height = Screen.height;
		Texture2D tex = new Texture2D( width, height, TextureFormat.RGB24, false );
		
		// Read screen contents into the texture
		tex.ReadPixels( new Rect(0, 0, width, height), 0, 0 );
		tex.Apply();
		Byte[] bytes = tex.EncodeToPNG();
		Destroy( tex );

		Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

		// Create a Web Form
		WWWForm form = new WWWForm();
		form.AddField("email", staticBehaviour.userEmail);
		form.AddField("level", staticBehaviour.currentLevel);
		form.AddField("autosave", "True");
		form.AddField("concours", concours.ToString());
		form.AddField("serversave", save.ToString());
		form.AddBinaryData("fileUpload", bytes, unixTimestamp + ".png", "image/png");
		// Upload to a cgi script
		WWW w = new WWW(staticBehaviour.screenshotUrl, form);
		yield return w;
		
		if (!String.IsNullOrEmpty(w.error))
			print(w.error);

		print (w.text);

		flag = true;
	}
	
	
	
	void OnMouseDown() {
		if (!flag) {
			flag = true;
			staticBehaviour.Pause(true, false);
		}
	}
}
