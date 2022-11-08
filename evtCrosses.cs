using UnityEngine;
using UnityEngine.UI;
using System.Collections;




public class evtCrosses : MonoBehaviour {



	// Use this for initialization
	void Start () {}
	// Update is called once per frame
	void Update () {
		string value = "";
		int nb = evtWorld.crossTook - evtWorld.crossUsed;
		if (nb < 10) {
			value = "0" + nb;
		} else {
			value = "" + nb;
		}
		GameObject.Find(name + "/value").GetComponent<Text>().text = value;
		
		if (staticControls.isCrossButtonDown() && nb > 0) {
			evtWorld.scoreLevel += staticBehaviour.scoreCrossUsed;

			bool flag = evtFaithBar.getRidOfIdeas(staticBehaviour.ideaPerCross);

			if (staticBehaviour.playEffects) {
				GameObject.Find("Bruitages/CrossAction").GetComponent<AudioSource>().Play();
			}
		}
	}
}
