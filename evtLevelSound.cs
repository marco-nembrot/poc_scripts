using UnityEngine;
using UnityEngine.UI;



public class evtLevelSound : MonoBehaviour {
	public Texture soundOn;
	public Texture soundOff;
	
	
	
	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update () {
		if (staticBehaviour.playSound) {
			GetComponent<RawImage>().texture = soundOn;
		} else {
			GetComponent<RawImage>().texture = soundOff;
		}
	}
	
	
	
	void OnMouseDown() {
		staticBehaviour.playSound = !staticBehaviour.playSound;
	}
}
