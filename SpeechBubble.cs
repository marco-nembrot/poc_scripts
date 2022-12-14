using UnityEngine; // 41 Post - Created by DimasTheDriver on Dec/12/2011 . Part of the 'Unity: How to create a speech balloon' post. Available at: http://www.41post.com/?p=4545 
using System.Collections;



[ExecuteInEditMode]
public class SpeechBubble : MonoBehaviour {
	//this game object's transform
	private Transform goTransform;
	//the game object's position on the screen, in pixels
	private Vector3 goScreenPos;
	//the game objects position on the screen
	private Vector3 goViewportPos;
	
	//the width of the speech bubble
	public int bubbleWidth = 200;
	//the height of the speech bubble
	public int bubbleHeight = 100;
	
	//the text to display inside the bubble
	private int index;
	private string text;
	public string part1 = "";
	public string part2 = "";

	public int buttonWidth = 30;
	public int buttonHeight = 30;
	
	//display the bubble or not ?
	private bool flag;
	private bool destroy;
	
	//an offset, to better position the bubble 
	public float offsetX = 0;
	public float offsetY = 150;
	
	//an offset to center the bubble 
	private int centerOffsetX;
	private int centerOffsetY;
	
	//a material to render the triangular part of the speech balloon
	public Material mat;
	//a guiSkin, to render the round part of the speech balloon
	public GUISkin guiSkin;
	
	
	
	
	//use this for early initialization
	void Awake() {
		//get this game object's transform
		goTransform = this.GetComponent<Transform>();
	}
	
	
	
	
	//use this for initialization
	void Start() {
		//if the material hasn't been found
		if (!mat) {
			Debug.LogError("Please assign a material on the Inspector.");
			return;
		}
		//if the guiSkin hasn't been found
		if (!guiSkin) {
			Debug.LogError("Please assign a GUI Skin on the Inspector.");
			return;
		}

		index = 1;
		text = "";
		flag = false;
		destroy = false;

		//Calculate the X and Y offsets to center the speech balloon exactly on the center of the game object
		centerOffsetX = bubbleWidth/2;
		centerOffsetY = bubbleHeight/2;
	}
	
	
	
	//Called once per frame, after the update
	void LateUpdate() {
		//find out the position on the screen of this game object
		goScreenPos = Camera.main.WorldToScreenPoint(goTransform.position);	
		
		//Could have used the following line, instead of lines 70 and 71
		//goViewportPos = Camera.main.WorldToViewportPoint(goTransform.position);
		goViewportPos.x = goScreenPos.x/(float)Screen.width;
		goViewportPos.y = goScreenPos.y/(float)Screen.height;
	}
	
	
	
	void Update() {
		if (index == 1) {
			text = part1;
		} else if (index == 2) {
			text = part2;
		}
		
		if (index == 2 && staticControls.isCancelButtonDown()) {
			index = 1;
		}
		if (index == 2 && staticControls.isOkayButtonDown()) {
			destroy = true;
		}
		if (index == 1 && staticControls.isOkayButtonDown()) {
			index = 2;
		}
	}
	
	
	
	void OnTriggerEnter2D() {
		//reinitializing variables here because of issues with controls from controller
		index = 1;
		flag = true;
		destroy = false;
		Time.timeScale = 0.0f;
		staticBehaviour.isPauseAllowed = false;
		transform.parent.gameObject.GetComponent<evtUpAndDown>().interval_up = 0;
		transform.parent.gameObject.GetComponent<evtUpAndDown>().interval_down = 0;
	}
	
	
	
	//Draw GUIs
	void OnGUI() {
		if (flag) {
			//Begin the GUI group centering the speech bubble at the same position of this game object. After that, apply the offset
			GUI.BeginGroup(new Rect(goScreenPos.x-centerOffsetX-offsetX,Screen.height-goScreenPos.y-centerOffsetY-offsetY,bubbleWidth,bubbleHeight));
			int buttonY = bubbleHeight - buttonHeight - 10;
				//Render the round part of the bubble
				GUI.Label(new Rect(0, 0, bubbleWidth, bubbleHeight), "", guiSkin.customStyles[0]);
				//Render the text
				GUI.Label(new Rect(30, 25, bubbleWidth - 50, bubbleHeight - 10), text, guiSkin.label);
				if (index == 1) {
					//If the button is pressed, close the bubble
					if(GUI.Button(new Rect(150, buttonY, buttonWidth, buttonHeight), ">")) {
						index = 2;
					}
				}
				if (index == 2) {
					if (GUI.Button(new Rect(120, buttonY, buttonWidth, buttonHeight), "<")) {
						index = 1;
					}
					if (GUI.Button(new Rect(160, buttonY, 100, buttonHeight), "J'ai compris !")) {
						destroy = true;
					}
				}
			
			
			GUI.EndGroup();
		} 

		if (flag && destroy) {
			Time.timeScale = 1.0f;
			staticBehaviour.isPauseAllowed = true;
			GameObject.Destroy(transform.parent.gameObject);
		}
	}
	//Called after camera has finished rendering the scene
	void OnRenderObject() {
		if (flag) {
			//push current matrix into the matrix stack
			GL.PushMatrix();
			//set material pass
			mat.SetPass(0);
			//load orthogonal projection matrix
			GL.LoadOrtho();
			//a triangle primitive is going to be rendered
			GL.Begin(GL.TRIANGLES);
		
				//set the color
				GL.Color(Color.white);
				
				//Define the triangle vetices
				GL.Vertex3(goViewportPos.x, goViewportPos.y+(offsetY/3)/Screen.height, 0.1f);
				GL.Vertex3(goViewportPos.x - (bubbleWidth/3)/(float)Screen.width, goViewportPos.y+offsetY/Screen.height, 0.1f);
				GL.Vertex3(goViewportPos.x - (bubbleWidth/8)/(float)Screen.width, goViewportPos.y+offsetY/Screen.height, 0.1f);
			
			GL.End();
			//pop the orthogonal matrix from the stack
			GL.PopMatrix();
		}
	}
}