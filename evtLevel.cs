using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class evtLevel : CustomEvent
{
	public string level;
	public Color onEnterColor = Color.green;
	public Color onExitColor = Color.white;
	public int onEnterFontSize = 90;
	public int onExitFontSize = 70;



	// Use this for initialization
	new void Start () {
		if (this.name.Equals("nextLevel")) {
			GetComponent<Text>().fontSize = -100;
        }
        base.Start();
    }
	// Update is called once per frame
	void Update () {}



    public override void OnPointerEnterDelegate(PointerEventData data)
    {
		if (GetComponent<Text>()) {
			GetComponent<Text>().color = onEnterColor;
			GetComponent<Text>().fontSize = onEnterFontSize;
		}
		if (GetComponent<AudioSource>() && staticBehaviour.playEffects) {
			GetComponent<AudioSource>().Play();
		}
	}

    public override void OnPointerExitDelegate(PointerEventData data)
    {
		if (GetComponent<Text>()) {
			GetComponent<Text>().color = onExitColor;
			GetComponent<Text>().fontSize = onExitFontSize;
		}
	}

    public override void OnPointerDownDelegate(PointerEventData data)
    {
        SceneManager.LoadScene(level);
	}



	private void Active() {
		level = staticBehaviour.nextLevel;
		GetComponent<Text>().fontSize = onExitFontSize;
	}
}
