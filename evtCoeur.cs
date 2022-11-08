using UnityEngine;
using System.Collections;



public class evtCoeur : MonoBehaviour {
	private bool onEarth;
	private float deltaTime;
	private GameObject master;

	public int timeToTimer;
	public int timeTimerStart;
	private int timeTimerStop;

	public Color into;
	public Color end;


	
	// Use this for initialization
	void Start () {
		onEarth = false;
		timeTimerStop = timeTimerStart + 5;
		master = GameObject.Find (this.name + "-blocs").gameObject;
		foreach (Transform padawan in master.transform) {
			padawan.gameObject.SetActive(false);
		}
	}
	// Update is called once per frame
	void Update () {
		if (onEarth && !staticBehaviour.isPaused) {
			int time = Mathf.CeilToInt(Time.time - deltaTime);
			if (time == timeToTimer) {
				if (staticBehaviour.playEffects) {
					GameObject.Find("Bruitages/TimerHeart").GetComponent<AudioSource>().Play();
				}
				GameObject.Find("Background").GetComponent<SpriteRenderer>().color = end;
			}
			if (time == timeTimerStop) {
				GameObject.Find("Background").GetComponent<SpriteRenderer>().color = Color.white;
				foreach (Transform padawan in master.transform) {
					padawan.gameObject.SetActive(false);
				}
			}
			if (time > timeTimerStart) {
				float timeF = ((Time.time - deltaTime) % 2) * 10;
				foreach (Transform padawan in master.transform) {
					if (timeF % 2 > 1) {
						padawan.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
					} else {
						padawan.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
					}
				}
			}
		}
	}
	
	
	
	void OnTriggerEnter2D(Component collider) {
		if (collider.name.Equals(evtWorld.characterScript.getCharacterName())) {
			onEarth = true;
			deltaTime = Time.time;
			foreach (Transform padawan in master.transform) {
				padawan.gameObject.SetActive(true);
				padawan.gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
			}
			GameObject.Find("Bruitages/TimerHeart").GetComponent<AudioSource>().Stop();
			GameObject.Find("Background").GetComponent<SpriteRenderer>().color = into;
		}
	}
}
