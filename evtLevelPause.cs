using UnityEngine;
using UnityEngine.UI;



public class evtLevelPause : MonoBehaviour {
	public Texture gameOn;
	public Texture gameOff;



	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update () {
		if (staticControls.isPauseButtonDown()) {
			staticBehaviour.Pause(!staticBehaviour.isPaused);
		}

		if (staticBehaviour.isPaused) {
			GetComponent<RawImage>().texture = gameOn;
		} else {
			GetComponent<RawImage>().texture = gameOff;
		}
	}
	
	
	
	void OnMouseDown() {
		staticBehaviour.Pause(!staticBehaviour.isPaused);
	}
}
