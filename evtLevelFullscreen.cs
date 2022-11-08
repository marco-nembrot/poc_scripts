using UnityEngine;
using UnityEngine.UI;




public class evtLevelFullscreen : MonoBehaviour {
	public Texture windowed;
	public Texture fullscreen;
	
	
	
	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update () {
		if (Screen.fullScreen) {
			GetComponent<RawImage>().texture = fullscreen;
		} else {
			GetComponent<RawImage>().texture = windowed;
		}
	}
	
	
	
	void OnMouseDown() {
		Screen.fullScreen = !Screen.fullScreen;
	}
}
