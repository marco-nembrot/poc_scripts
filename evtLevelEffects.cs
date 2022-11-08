using UnityEngine;
using UnityEngine.UI;



public class evtLevelEffects : MonoBehaviour {
	public Texture effectsOn;
	public Texture effectsOff;
	
	
	
	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update () {
		if (staticBehaviour.playEffects) {
			GetComponent<RawImage>().texture = effectsOn;
		} else {
			GetComponent<RawImage>().texture = effectsOff;
		}
	}
	
	
	
	void OnMouseDown() {
		staticBehaviour.playEffects = !staticBehaviour.playEffects;
	}
}
