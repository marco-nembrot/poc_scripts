using UnityEngine;
using System.Collections;



public class evtCroix : MonoBehaviour {
	private int destroyingIdeas;
	public float rotationSpeed = 2.0f;



	// Use this for initialization
	void Start () {
		destroyingIdeas = staticBehaviour.ideaPerCross;
	}
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, transform.rotation.y + rotationSpeed, 0);
	}
	
	
	
	void OnTriggerEnter2D(Component collider) {
		if (collider.name.Equals(evtWorld.characterScript.getCharacterName())) {
			evtWorld.scoreLevel += staticBehaviour.scoreCrossGet;
			evtWorld.crossTook++;

			bool flag = evtFaithBar.getRidOfIdeas(destroyingIdeas);
			if (flag) {
				evtWorld.scoreLevel += staticBehaviour.scoreCrossUsedOnGet;
				evtWorld.crossUsed++;
			}
			if (staticBehaviour.playEffects) {
				GameObject.Find("Bruitages/CollisionCross").GetComponent<AudioSource>().Play();
			}
			
			GameObject.Destroy(gameObject);
		}
	}
}
