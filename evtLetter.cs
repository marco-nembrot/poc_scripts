using UnityEngine;
using UnityEngine.UI;



public class evtLetter : MonoBehaviour {
	public int index;
	public Color colorParent;
	public GameObject parent;
	
	
	
	// Use this for initialization
	void Start () {
		int random = Mathf.CeilToInt(Random.Range(1, 7));
		GetComponent<Animator>().SetInteger("flag", random);
	}
	// Update is called once per frame
	void Update () {
		//utilisée ici pour une éventuelle reprise/continuation de niveau
		if (evtWorld.areLettersCollected[index]) {
			parent.GetComponent<Text>().color = colorParent;
			GameObject.Destroy(gameObject);
		}
	}
	
	
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.name.Equals(evtWorld.characterScript.getCharacterName())) {
			evtWorld.scoreLevel += staticBehaviour.scoreLetterOneGet;
			evtWorld.lettersCollected += 1;
			evtWorld.areLettersCollected[index] = true;
			staticBehaviour.lettersCollected++;
			if (staticBehaviour.playEffects) {
				if (evtWorld.lettersCollected == evtWorld.areLettersCollected.Length) {
					evtWorld.scoreLevel += staticBehaviour.scoreLetterAllGet;
					GameObject.Find("Bruitages/CollisionLastLetter").GetComponent<AudioSource>().Play();
				} else {
					GameObject.Find("Bruitages/CollisionLetter").GetComponent<AudioSource>().Play();
				}
			}
			Component.Destroy(GetComponent<BoxCollider2D>());
		}
	}
}
