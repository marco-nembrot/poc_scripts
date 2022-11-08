using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class evtWorld : MonoBehaviour {
	public string currentLevel;

	//points d'intéret choisis pour placer les éléments mobiles du niveau
	public Vector3[] POI;

	//intervalles d'apparition des idées noires
	public Vector2 boundX;
	public Vector2 boundY;

	//variables utilisées pour l'affichage des résultats du niveau 
	private int nbLetters;
	public static string[] letters;
	public static int lettersCollected;
	public static bool[] areLettersCollected;
	public static int ideas;
	public static int crossTook;
	public static int crossUsed;
	public static int timeLevel;
	public static int scoreLevel;
	
	private bool shiftLeft;
	
	public bool onFaith = true;
	public bool combinedFaith = true;
	public bool combinedScore = true;
	public bool combinedCrosses = true;
	public bool combinedTime = true;

	public static evtCharacter characterScript;


	
	void Awake() {}
	// Use this for initialization
	void Start () {
		characterScript = GameObject.Find(getMainCharacterObjectName()).GetComponent<evtCharacter>();

		ideas = 0;
		scoreLevel = 0;
		shiftLeft = false;
		lettersCollected = 0;

		if (combinedCrosses) {
			crossTook = staticBehaviour.crossCollected;
			crossUsed = staticBehaviour.crossUsed;
		} else {
			crossTook = 0;
			crossUsed = 0;
		}
		nbLetters = GameObject.Find ("Letters").transform.childCount;
		
		staticBehaviour.currentLevel = currentLevel;
		staticBehaviour.planeIntro = "Results";
		staticBehaviour.planeIntroDone = false;
		staticBehaviour.lettersMet += nbLetters;
		
		letters = new string[nbLetters];
		foreach (Transform child in GameObject.Find("Letters").transform) {
			int i = child.GetComponent<evtLetter>().index;
			string l = child.GetComponent<TextMesh>().text;
			letters[i] = l;
		}

		areLettersCollected = new bool[nbLetters];
		for (int i = 0; i < nbLetters; i++) {
			areLettersCollected[i] = false;
		}
		
		giveRandomPosition("Letters", false);
	}



	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			shiftLeft = true;
		} 
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			shiftLeft = false;
		}
		if (shiftLeft && Input.GetKeyDown(KeyCode.LeftControl)) {
			giveRandomPosition("Letters", true);
		}
		if (shiftLeft && Input.GetKeyDown(KeyCode.Q)) {
			staticBehaviour.planeIntro = "Jouer";
            SceneManager.LoadScene("Introduction");
		}
		
		if (Input.GetKeyDown(KeyCode.Z)) {
			print(GameObject.Find(characterScript.getCharacterName()).transform.position);
		}
	}
	
	
	
	void giveRandomPosition(string name, bool flag) {
		int min = 0;
		int max = POI.Length;
		if (flag) {
			resetPOIz();
		}
		foreach (Transform child in GameObject.Find(name).transform) {
			int random = Mathf.CeilToInt(Random.Range(min, max));
			while (POI[random].z == -1) {
				random = Mathf.CeilToInt(Random.Range(min, max));
			}
			child.gameObject.transform.position = POI[random];
			POI[random].z = -1;
		}
	}
	void resetPOIz() {
		for (int c = 0; c < POI.Length; c++) {
			POI[c].z = 0;
		}
	}



	public static string getMainCharacterObjectName() {
		if (GameObject.Find("Quit").GetComponent<evtLevelQuit>().plane.Equals("Tutorial")) {
			return "Character";
		} else {
			return "Character_" + staticBehaviour.characterId;
		}
	}
}
