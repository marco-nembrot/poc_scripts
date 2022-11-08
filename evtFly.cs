using UnityEngine;
using System.Collections;



public class evtFly : MonoBehaviour {
	public float hSpeed = 10.0f;
	public float vSpeed = 10.0f;
	
	
	
	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update() {
		float translation = Input.GetAxis("Vertical") * vSpeed;
		float rotation = Input.GetAxis("Horizontal") * hSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(rotation, translation, 0);
	}
}