using UnityEngine;
using UnityEngine.EventSystems;



public class evtHoverCursor : CustomEvent
{
	public Texture2D cursor;



	// Use this for initialization
	new void Start ()
    {
        base.Start();
    }
	// Update is called once per frame
	void Update () {}


    public override void OnPointerEnterDelegate(PointerEventData data)
    {
		evtCursor.display = false;
		evtCursor.otherCursor = cursor;
    }

    public override void OnPointerExitDelegate(PointerEventData data)
    {
		evtCursor.display = true;
	}

    public override void OnPointerDownDelegate(PointerEventData data)
    {
		evtCursor.display = true;
	}
}
