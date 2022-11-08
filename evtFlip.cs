using UnityEngine;
using System.Collections;



public class evtFlip : MonoBehaviour {
	
	
	
	// Use this for initialization
	void Start () {
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	// Update is called once per frame
	void Update () {}
}
