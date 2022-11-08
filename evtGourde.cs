using UnityEngine;
using System.Collections;



public class evtGourde : MonoBehaviour {
	public int value;



	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update () {}



	void OnTriggerEnter2D(Component collider) {
		if (collider.name.Equals(evtWorld.characterScript.getCharacterName())) {
			int v = value;
			if (v == -1) {
				v = staticBehaviour.faithMaxAmount;
			}
			if (v == -2) {
				v = staticBehaviour.faithMaxAmount / 2;
			}

			staticBehaviour.gourdMet++;
			staticBehaviour.waterPtMet += v;
			staticBehaviour.faithCombinedAmount += v;
			GameObject.Find("faithBar").GetComponent<evtFaithBar>().setFaithAmount(v, true);

			if (staticBehaviour.playEffects) {
				GameObject.Find("Bruitages/CollisionGourde").GetComponent<AudioSource>().Play();
			}
			
			GameObject.Destroy(gameObject);
		}
	}
}
