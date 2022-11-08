using UnityEngine;
using System.Collections;



public class evtMoveIntoCircle : MonoBehaviour {
	public float speed = 1;
	public int width = 2;
	public int height = 2;
	private float timeCounter;



	// Use this for initialization
	void Start () {
		timeCounter = 0;
	}
	// Update is called once per frame
	void Update () {
		if (!staticBehaviour.isPaused) {
			timeCounter += Time.deltaTime + speed;
			
			float x = Mathf.Cos (timeCounter) * width;
			float y = Mathf.Sin(timeCounter) * height;
			transform.position = 
				RotatePointAroundPivot(transform.position, transform.parent.position, Quaternion.Euler(0, y, x));
		}
	}



	private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle) {
		return angle * ( point - pivot) + pivot;
	}
	/**************************************************************************************************************
	 * http://gamedev.stackexchange.com/questions/61981/unity3d-orbit-around-orbiting-object-transform-rotatearound
	 **************************************************************************************************************
	public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle) {
	   return angle * ( point - pivot) + pivot;
	}
	transform.position = 
    RotatePointAroundPivot(transform.position,
                           transform.parent.position,
                           Quaternion.Euler(0, OrbitDegrees * Time.deltaTime, 0));
   ****************************************************************************************************************/
}
