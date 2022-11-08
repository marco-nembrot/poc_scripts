using UnityEngine;
using System.Collections;


/***************************************
 * Management of the Holy Spirit action
 ***************************************/ 
public class evtSpirit : MonoBehaviour {
	public Vector3 destination;
	private bool onTarget;
	private Component target;
	
	
	
	// Use this for initialization
	void Start () {
		onTarget = false;
	}
	// Update is called once per frame
	void Update () {
		if (onTarget) {
			target.GetComponent<Rigidbody2D>().gravityScale = 0;
			target.transform.position = Vector2.MoveTowards(target.transform.position, destination, 0.05f);
			if (Vector3.Equals(target.transform.position, destination)) {
				onTarget = false;
				evtWorld.characterScript.setFaith(false);
				target.GetComponent<Rigidbody2D>().gravityScale = 1;
			}
		}
	}
	
	
	
	void OnTriggerEnter2D(Component collider) {
		if (collider.name.Equals(evtWorld.characterScript.getCharacterName())) {
			onTarget = true;
			target = collider;
			evtWorld.characterScript.setFaith(true);
		}
	}
}
