using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class evtGif : MonoBehaviour {
	public Texture2D[] textures;
	public float frameTime = 10;
	


	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update () {}
	
	
	
	void OnEnable(){
		float time = 1 / frameTime;
		StartCoroutine(AnimateTextures(time));
	}
	void OnDisable() {
		StopAllCoroutines();
	}



	IEnumerator AnimateTextures(float time) {
		int i = 0;
		
		while (true) {
			GetComponent<RawImage>().texture = textures[i];
			
			if (i < textures.Length - 1)
				i += 1;
			else
				i = 0;
			
			yield return new WaitForSeconds(time);
		}
	}
}
