using UnityEngine;
using System.Collections;



public class evtAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update () {
		if (!staticBehaviour.playSound) {
			GetComponent<AudioSource>().Stop();
		}
		if (staticBehaviour.playSound && !GetComponent<AudioSource>().isPlaying) {
			GetComponent<AudioSource>().Play();
		}
	}
}
