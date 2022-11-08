using UnityEngine;
using System.Collections;



public class staticControls : MonoBehaviour {
	public static KeyCode pauseKey = KeyCode.P;
	public static KeyCode quitKey = KeyCode.Q;
	public static KeyCode rosarioKey = KeyCode.N;



	public static bool isJumpButtonDown() {
		return Input.GetButtonDown("Controller_Jump");
	}

	public static bool isCrossButtonDown() {
		return Input.GetButtonDown("Controller_Cross");
	}
	
	public static bool isFaithButtonDown() {
		return Input.GetButtonDown("Controller_Faith");
	}
	public static bool isFaithButtonUp() {
		return Input.GetButtonUp("Controller_Faith");
	}
	
	public static bool isSoulButtonDown() {
		return Input.GetButtonDown("Controller_Soul");
	}
	
	public static bool isIdeaButtonDown() {
		return Input.GetButtonDown("Controller_Idea");
	}
	
	public static bool isRosarioButtonDown() {
		return Input.GetKeyDown(rosarioKey);
	}
	public static bool isRosarioButton1Down() {
		return Input.GetButtonDown("Controller_Rosario-1");
	}
	public static bool isRosarioButton1Up() {
		return Input.GetButtonUp("Controller_Rosario-1");
	}
	public static bool isRosarioButton2Down() {
		return Input.GetButtonDown("Controller_Rosario-2");
	}
	public static bool isRosarioButton2Up() {
		return Input.GetButtonUp("Controller_Rosario-2");
	}

	public static bool isPauseButtonDown() {
		return Input.GetButtonDown("Controller_Pause");
	}
	
	public static bool isQuitButtonDown() {
		return Input.GetKeyDown(quitKey) || Input.GetKeyDown(KeyCode.Escape);
	}
	
	public static bool isInformationsButtonDown() {
		return Input.GetButtonDown("Controller_Controls");
	}

	public static bool isOkayButtonDown() {
		return Input.GetButtonDown("Controller_Okay");
	}
	public static bool isCancelButtonDown() {
		return Input.GetButtonDown("Controller_Cancel");
	}
}
