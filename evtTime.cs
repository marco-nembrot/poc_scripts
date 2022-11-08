using UnityEngine;
using UnityEngine.UI;



public class evtTime : MonoBehaviour {
	public int duree;			//needs to be public for access
	private float deltaTime;



	// Use this for initialization
	void Start () {
		staticBehaviour.first = false;
		deltaTime = Time.time;
	}
	// Update is called once per frame
	void Update () {
		string value = "";
		duree = Mathf.CeilToInt(Time.time - deltaTime);
		if (duree < 10) {
			value = "000" + duree;
		} else if (duree < 100) {
			value = "00" + duree;
		} else if (duree < 1000) {
			value = "0" + duree;
		}
		GameObject.Find ("Time/value").GetComponent<Text>().text = value;
	}
}
