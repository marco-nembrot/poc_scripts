using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class evtDoor : MonoBehaviour {
	public string action = "Teleportation";

	public Vector2 teleportation;
	
	
	
	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update () {}
	
	
	
	void OnTriggerEnter2D() {
		evtWorld t = GameObject.Find("World").GetComponent<evtWorld>();
		if (action.Equals("Next")) {
			if (t.onFaith && t.combinedFaith) {
				staticBehaviour.faithCurrentAmount = GameObject.Find("FaithBar").GetComponent<evtFaithBar>().getFaithAmount();
			}
			evtWorld.timeLevel = GameObject.Find("Time").GetComponent<evtTime>().duree;
			if (t.combinedTime) {
				staticBehaviour.combinedTime += evtWorld.timeLevel;
			}
			if (t.combinedScore) {
				staticBehaviour.combinedScore += evtWorld.scoreLevel;
			}
			if (t.combinedCrosses) {
				staticBehaviour.crossCollected += evtWorld.crossTook;
				staticBehaviour.crossUsed += evtWorld.crossUsed;
			}

            SceneManager.LoadScene("Introduction");
		} else if (action.Equals("Teleportation")) {
			GameObject.Find ("Camera").transform.position = teleportation;
			GameObject.Find (evtWorld.characterScript.getCharacterName()).transform.position = teleportation;
		}
	}
}
