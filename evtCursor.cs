using UnityEngine;
using System.Collections;



public class evtCursor : MonoBehaviour {
	public static bool display = true;
	public static Texture2D otherCursor;
	
	public Texture2D cursor;



	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update () {}



	void OnGUI() {
		Vector3 mouse = Input.mousePosition;
		if (display) {
			Rect cursorRect = new Rect(mouse.x, Screen.height - mouse.y, cursor.width, cursor.height);
			GUI.Label(cursorRect, cursor);
		} else {
			Rect cursorEnter = new Rect(mouse.x, Screen.height - mouse.y, otherCursor.width, otherCursor.height);
			GUI.Label(cursorEnter, otherCursor);
		}
	}
}
