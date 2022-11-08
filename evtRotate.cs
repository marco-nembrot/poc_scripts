using UnityEngine;
using System.Collections;



public class evtRotate : MonoBehaviour {
	public float left;
	public float right;
	public float interval_left;
	public float interval_right;

	private bool isLeft;



	// Use this for initialization
	void Start () {
		isLeft = true;
	}
	// Update is called once per frame
	void Update () {
		if (!staticBehaviour.isPaused) {
			if (isLeft) {
				if (transform.rotation.z < interval_left) {
					transform.Rotate(0, 0, transform.rotation.z + left);
				} else {
					isLeft = false;
				}
			} else {
				if (transform.rotation.z > interval_right) {
					transform.Rotate(0, 0, transform.rotation.z + right);
				} else {
					isLeft = true;
				}
			}
		}
	}
}
