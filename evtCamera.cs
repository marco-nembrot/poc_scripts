using UnityEngine;
using System.Collections;



public class evtCamera : MonoBehaviour {
	public Transform target;
	public float smoothTime = 0.3f;
	
	private Transform thisTransform;
	private Vector2 velocity;

	public float upBorder;
	public float downBorder;
	public float leftBorder;
	public float rightBorder;
	


	// Use this for initialization
	void Start () {
		thisTransform = transform;
	}
	// Update is called once per frame
	void Update () {
		float smoothX;
		if (target.transform.position.x <= leftBorder || target.transform.position.x >= rightBorder) {
			smoothX = thisTransform.position.x;
		} else {
			smoothX = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref velocity.x, smoothTime);
		}
		float smoothY = Mathf.SmoothDamp(thisTransform.position.y, target.position.y, ref velocity.y, smoothTime);
		thisTransform.position = new Vector3(smoothX, smoothY, -5);
	}
}