using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class evtBoundaryDown : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update () {}
	
	
	
	void OnTriggerEnter2D(Component collider) {
		if (collider.name.Equals(evtWorld.characterScript.getCharacterName())) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
