using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class evtUrl : CustomEvent
{
	public string url = "http://www.";
	public Color onEnterColor;
	public Color onExitColor;
	public Texture2D onEnterCursor;



	// Use this for initialization
	new void Start () {
		if (GetComponent<Text>())
			GetComponent<Text>().color = onExitColor;
        base.Start();
    }
	// Update is called once per frame
	void Update () {}



    public override void OnPointerEnterDelegate(PointerEventData data)
    {
		evtCursor.display = false;
		evtCursor.otherCursor = onEnterCursor;
		if (GetComponent<Text>())
			GetComponent<Text>().color = onEnterColor;
	}

    public override void OnPointerExitDelegate(PointerEventData data)
    {
		evtCursor.display = true;
		if (GetComponent<Text>())
			GetComponent<Text>().color = onExitColor;
	}

    public override void OnPointerDownDelegate(PointerEventData data)
    {
		Application.OpenURL(url);
	}
}
