using UnityEngine;
using System.Collections;



public class evtDoorCollider : MonoBehaviour {
	public Sprite open;
	private Sprite close;


	
	// Use this for initialization
	void Start () {
		close = transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite;
	}	
	// Update is called once per frame
	void Update () {}
	
	
	
	void OnTriggerEnter2D() {
		transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite = open;
		if (staticBehaviour.playEffects) 
			GameObject.Find("Bruitages/DoorOpen").GetComponent<AudioSource>().Play();
	}
	void OnTriggerExit2D() {
		transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite = close;
		if (staticBehaviour.playEffects) 
			GameObject.Find("Bruitages/DoorClose").GetComponent<AudioSource>().Play();
	}
}
