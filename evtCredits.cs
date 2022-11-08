using UnityEngine;
using System.Collections;



public class evtCredits : MonoBehaviour {
	public float speed;
	public float limit;
	private bool crawling;


	// Use this for initialization
	void Start () {
		crawling = true;
		transform.position = new Vector3((float) 640, (float) 18.5, (float) 0.9);
	}
	// Update is called once per frame
	void Update () {
		if (!crawling)
			return;

		transform.Translate(0, Time.deltaTime * speed, 0);
		if (transform.position.y > limit)
        {

            crawling = false;
            evtTextIntroduction script = GameObject.Find("Plan_Credits/Retour_canvas/retourIntro").GetComponent<evtTextIntroduction>();
            script.callPlan("Informations");
        }
    }

    void OnEnable()
    {
        Start();
    }
}
