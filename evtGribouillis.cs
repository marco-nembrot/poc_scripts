using UnityEngine;
using System.Collections;



public class evtGribouillis : MonoBehaviour {
	private bool onTarget;
	private Component target;

	private int index;
	private float deltaTime;
	private bool child;
	private float colliderRadius;

	public static int timeToCallIdea = 10;
	public static int timeToDestroyIdea = 30;


	
	// Use this for initialization
	void Start () {
		index = -1;
		child = false;
		onTarget = false;
		colliderRadius = GetComponent<CircleCollider2D>().radius;
	}
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, transform.rotation.y + 2.0f, 0);
		
		if (onTarget) {
			Vector2 temp = new Vector2((target.transform.position.x - 0.1f) + (index * 0.04f), target.transform.position.y + 0.4f);
			transform.position = Vector2.MoveTowards(transform.position, temp, 0.1f);
		}
		
		if (index != -1) {
			int time = Mathf.CeilToInt(Time.time - deltaTime);
			if (time == timeToCallIdea) {
				if (!child) {
					if (staticBehaviour.playEffects) {
						GameObject.Find("Bruitages/CallIdea").GetComponent<AudioSource>().Play();
					}
					
					child = true;
					evtWorld t = GameObject.Find("World").GetComponent<evtWorld>();
					float x = Random.Range(t.boundX.x, t.boundX.y);
					float y = Random.Range(t.boundY.x, t.boundY.y);
					GameObject clone = (GameObject) Instantiate(gameObject, new Vector2(x, y), Quaternion.identity);
					clone.GetComponent<CircleCollider2D>().radius = colliderRadius;
					clone.transform.parent = transform.parent;
					evtWorld.scoreLevel += staticBehaviour.scoreIdeaOnCall;
				}
			}
			if (time == timeToDestroyIdea) {
				evtWorld.ideas--;
				staticBehaviour.ideaDestroyed++;
				evtWorld.scoreLevel += staticBehaviour.scoreIdeaDestroyed;
				GameObject.Destroy(gameObject);
			}
		}
	}
	
	
	
	void OnTriggerEnter2D(Component collider) {
		if (collider.name.Equals(evtWorld.characterScript.getCharacterName())) {
			index = 0;
			onTarget = true;
			target = collider;
			evtWorld.scoreLevel += staticBehaviour.scoreIdeaOnCollider;
			deltaTime = Time.time;
			evtWorld.ideas++;
			staticBehaviour.ideaMet++;
			GetComponent<CircleCollider2D>().radius = 0.0f;
			
			if (staticBehaviour.playEffects) {
				GameObject.Find("Bruitages/CollisionIdea").GetComponent<AudioSource>().Play();
			}
		}
	}



	public bool isOnTarget() {
		return onTarget && index >= 0;
	}
}