using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class evtLevelDescription : CustomEvent
{
    [TextArea]
    public string description;

	string parent = "Plan_Tutorial/Selection";
    Text component;



	// Use this for initialization
	new void Start () {
        component = GameObject.Find(parent + "/Text").GetComponent<Text>();
        GameObject.Find(parent + "/Title").GetComponent<Text>().enabled = false;
        base.Start();
    }
	// Update is called once per frame
	void Update () {}



    public override void OnPointerEnterDelegate(PointerEventData data)
    {
        GameObject.Find(parent + "/Title").GetComponent<Text>().enabled = true;
        component.text = description;
    }

    public override void OnPointerExitDelegate(PointerEventData data)
    {
        GameObject.Find(parent + "/Title").GetComponent<Text>().enabled = false;
        component.text = "";
	}
}
