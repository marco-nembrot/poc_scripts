using UnityEngine;
using System.Collections;



public class evtUpAndDown : MonoBehaviour {
	public float up;
	public float down;
	public float interval_up;
	public float interval_down;
	
	private bool isUp;
	private Vector2 init;
	
	
	
	// Use this for initialization
	void Start () {
		isUp = true;
		init = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!staticBehaviour.isPaused) {
			if (isUp) {
				if (transform.position.y < init.y + up) {
					transform.position = new Vector2(transform.position.x, transform.position.y + interval_up);
				} else {
					isUp = false;
				}
			} else {
				if (transform.position.y > init.y - down) {
					transform.position = new Vector2(transform.position.x, transform.position.y - interval_down);
				} else {
					isUp = true;
				}
			}
		}
	}
}
