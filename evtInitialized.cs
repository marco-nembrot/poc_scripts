using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;



public class evtInitialized : MonoBehaviour
{
    private bool flagUser;
    private bool flagProfil;
    private bool flagConcours;

	private bool isInitialized;


	// Use this for initialization
	void Start() {
		flagUser = flagProfil = flagConcours = true;
		if (!staticBehaviour.isInitialized) {
			flagUser = flagProfil = flagConcours = false;

			Application.ExternalCall("getUserFromBrowser");
			#if UNITY_EDITOR
				_init("i.nembrot@laposte.net");
			#endif

			// Getting plateforme textures
			int index = 0;
			foreach (Transform child in GameObject.Find("World/Textures").transform) {
				staticBehaviour.plateformeTextureArr[index++] = child.GetComponent<Image>();
			}
		}

		if (flagProfil) {
			actionActivate();
		}
    }
    // Update is called once per frame
    void Update () {
		if (staticBehaviour.isInitialized) {
			if (!flagProfil) {
				flagProfil = true;
				actionActivate();
				StartCoroutine(getUserProfil());
			}

			if (!flagConcours) {
				flagConcours = true;
				StartCoroutine("getActiveConcours");
			}
		}
	}



    // Answering a JS call from the browser
    private void _init(string obj) {
		if (!flagUser) {
			var results = obj;
			//var results = JSONNode.Parse(obj);
			//Debug.Log(results);
			StartCoroutine(getUserData(results));
		}
    }
	// Activating button-like texts
	private void actionActivate() {
		Transform tmp = GameObject.Find("Plan_Introduction").transform;
		tmp.Find("Chargement_canvas").gameObject.SetActive(false);
		tmp.Find("Jouer_canvas").gameObject.SetActive(true);
		tmp.Find("Informations_canvas").gameObject.SetActive(true);
	}




    private IEnumerator getUserData(string emailUser) {
        PlayerPrefs.SetString("Player Email", staticBehaviour.userEmail);

        // We should only read the screen after all rendering is complete
        yield return new WaitForEndOfFrame();

        // Create a Web Form
        WWWForm form = new WWWForm();
        form.AddField("action", "GET");
        form.AddField("user", emailUser);

        // Upload to a cgi script
        WWW w = new WWW(staticBehaviour.profilUrl, form);
        yield return w;

        var results = JSONNode.Parse(w.text);
		print(">>>>>>>>>> Loading user data...");
		//print (w.text);
		//*
		if (results == null){
            staticBehaviour.userConnexionId = 0;
        } else {
			staticBehaviour.userEmail = emailUser;
            staticBehaviour.userConnexionId = Convert.ToInt32(results["id"]);
            staticBehaviour.userAliasId = Convert.ToInt32(results["alias"]);
            staticBehaviour.userName = Convert.ToString(results["pseudo"]);
		}
		//*/
		flagUser = true;
		staticBehaviour.isInitialized = true;

		if (!String.IsNullOrEmpty(w.error))
            print(w.error);
    }
    private IEnumerator getUserProfil() {
		// We should only read the screen after all rendering is complete
		yield return new WaitForEndOfFrame();
		
		// Create a Web Form
		WWWForm form = new WWWForm();
		form.AddField("action", "profil");
		form.AddField("connexion", staticBehaviour.userConnexionId);

		// Upload to a cgi script
		WWW w = new WWW(staticBehaviour.profilUrl, form);
		yield return w;
		
		var results = JSONNode.Parse(w.text);
		print(">>>>>>>>>> Loading user profile...");
		//Debug.Log(results);
		//*
		if (results != null) {
			staticBehaviour.characterId = results["personnage"];
			staticBehaviour.plateforme = results["plateforme"];
			staticBehaviour.difficulty = results["difficulte"];
			staticBehaviour.knowledge = results["reglages"];
			
			staticBehaviour.crossCollected = int.Parse(results["crossCollected"]);
			staticBehaviour.crossUsed = int.Parse(results["crossUsed"]);
			staticBehaviour.ideaMet = int.Parse(results["ideaMet"]);
			staticBehaviour.ideaDestroyed = int.Parse(results["ideaDestroyed"]);
			staticBehaviour.gourdMet = int.Parse(results["gourdMet"]);
			staticBehaviour.waterPtMet = int.Parse(results["waterPtMet"]);
			staticBehaviour.waterPtConsumed = int.Parse(results["waterPtConsumed"]);
			staticBehaviour.faithCurrentAmount = float.Parse(results["faithCurrentAmount"]);
			staticBehaviour.faithMaxAmount = int.Parse(results["faithMaxAmount"]);
			staticBehaviour.faithCombinedAmount = float.Parse(results["faithCombinedAmount"]);
			staticBehaviour.rosario = int.Parse(results["rosario"]);
			staticBehaviour.unitedSouls = int.Parse(results["unitedSouls"]);

			staticBehaviour.scoreCrossGet = int.Parse(results["scoreCrossGet"]) + int.Parse(results["scoreCrossGetOp"]);
			staticBehaviour.scoreCrossUsed = int.Parse(results["scoreCrossUsed"]) + int.Parse(results["scoreCrossUsedOp"]);
			staticBehaviour.scoreCrossUsedOnGet = int.Parse(results["scoreCrossUsedOnGet"]) + int.Parse(results["scoreCrossUsedOnGetOp"]);
			staticBehaviour.scoreIdeaOnCall = int.Parse(results["scoreIdeaOnCall"]) + int.Parse(results["scoreIdeaOnCallOp"]);
			staticBehaviour.scoreIdeaOnWater = int.Parse(results["scoreIdeaOnWater"]) + int.Parse(results["scoreIdeaOnWaterOp"]);
			staticBehaviour.scoreIdeaOnCollider = int.Parse(results["scoreIdeaOnCollider"]) + int.Parse(results["scoreIdeaOnColliderOp"]);
			staticBehaviour.scoreIdeaDestroyed = int.Parse(results["scoreIdeaDestroyed"]) + int.Parse(results["scoreIdeaDestroyedOp"]);
			staticBehaviour.scoreLetterOneGet = int.Parse(results["scoreLetterGetOne"]) + int.Parse(results["scoreLetterGetOneOp"]);
			staticBehaviour.scoreLetterAllGet = int.Parse(results["scoreLetterGetAll"]) + int.Parse(results["scoreLetterGetAllOp"]);
			staticBehaviour.scoreOnRosario = int.Parse(results["scoreOnRosario"]) + int.Parse(results["scoreOnRosarioOp"]);
			staticBehaviour.scoreUnitedSouls = int.Parse(results["scoreUnitedSouls"]) + int.Parse(results["scoreUnitedSoulsOp"]);

			staticBehaviour.ideaPerCross = int.Parse(results["ideaPerCross"]) + int.Parse(results["ideaPerCrossOp"]);
			staticBehaviour.ideaPerWater = int.Parse(results["ideaPerWater"]) + int.Parse(results["ideaPerWaterOp"]);

			//staticBehaviour.userPlayId = int.Parse(results["onPlay"]);
			staticBehaviour.playSound = int.Parse(results["soundOn"]) == 1;
			staticBehaviour.playEffects = int.Parse(results["effectsOn"]) == 1;


			evtFaithBar.minTimeBetweenPrayers = int.Parse(results["timeMinBetweenPrayers"]) + int.Parse(results["timeMinBetweenPrayersOp"]);
			evtGribouillis.timeToCallIdea = int.Parse(results["timeToCallIdea"]) + int.Parse(results["timeToCallIdeaOp"]);
			evtGribouillis.timeToDestroyIdea = int.Parse(results["timeToDestroyIdea"]) + int.Parse(results["timeToDestroyIdeaOp"]);

			if (staticBehaviour.plateforme != "") {
				staticBehaviour.plateformeTexture = GameObject.Find("Textures/" + staticBehaviour.plateforme).GetComponent<Image>();
			}
		}
		//*/
		if (!String.IsNullOrEmpty(w.error))
			print(w.error);
	}
	
	
	
	private IEnumerator getActiveConcours() {
		// We should only read the screen after all rendering is complete
		yield return new WaitForEndOfFrame();
		
		// Create a Web Form
		WWWForm form = new WWWForm();
		form.AddField("action", "concours");
		form.AddField("alias", staticBehaviour.userAliasId);

		// Upload to a cgi script
		WWW w = new WWW(staticBehaviour.databaseUrl, form);
		yield return w;
		
		var results = JSONNode.Parse(w.text);
		print(">>>>>>>>>> Loading active contest...");
		//print (results);
		//*
		if (results != null) {
			staticBehaviour.concours = true;
			staticBehaviour.concoursTitle = results["nom"]; 
			staticBehaviour.concoursDate = results["dateE"];
		}

		if (!String.IsNullOrEmpty(w.error))
			print(w.error);
	}
}
