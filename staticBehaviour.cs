using UnityEngine;
using UnityEngine.UI;



public class staticBehaviour : MonoBehaviour {
	public static bool first = true;
	public static string currentLevel = "";
	public static string nextLevel = "";

	public static bool concours = false;
	public static string concoursTitle = "";
	public static string concoursDate = "";
	
	public static string planeIntro = "retourIntro";
	public static bool planeIntroDone = false;

	public static string personnage = "";
	public static string characterId = "";
	public static string difficulty = "Normal";
	public static string knowledge = "Novice";
	public static string plateforme = "";
	public static Image plateformeTexture = null;
	public static Image[] plateformeTextureArr = new Image[4];

	public static bool playSound = false;
	public static bool playSound_last = false;
	public static bool playEffects = false;
	public static bool playEffects_last = false;
	public static bool isPaused = false;

	public static int ideaPerCross = 3;
	public static int ideaPerWater = 5;

	public static int lettersCollected = 0;
	public static int lettersMet = 0;
	
	public static int crossCollected = 0;
	public static int crossUsed = 0;
	public static int gourdMet = 0;
	public static int waterPtMet = 0;
	public static int waterPtConsumed = 0;
	public static float faithValueForCharacter = 0.05f;
	public static int faithMaxAmount = 10;
	public static float faithCurrentAmount = 0;
	public static float faithCombinedAmount = 0;
	public static int rosario = 0;
	public static int unitedSouls = 0;
	public static int ideaDestroyed = 0;
	public static int ideaMet = 0;

	public static int combinedTime = 0;
	public static int combinedScore = 0;

	public static int scoreCrossGet = 30;
	public static int scoreCrossUsed = -15;
	public static int scoreCrossUsedOnGet = -30;
	public static int scoreIdeaOnCall = -50;
	public static int scoreIdeaOnWater = -50;
	public static int scoreIdeaOnCollider = -20;
	public static int scoreIdeaDestroyed = 10;
	public static int scoreLetterOneGet = 20;
	public static int scoreLetterAllGet = 100;
	public static int scoreOnRosario = -100;
	public static int scoreUnitedSouls = 50;

	public static int userAliasId = -1;
	public static int userConnexionId = -1;              // Connexion ID
	public static string userName = "";
	public static string userEmail = "guest@poc_pm.fr";

	public static string baseUrl = "https://nembrot.club/POC/scripts/";
	public static string profilUrl = baseUrl + "profil.php";
	public static string databaseUrl = baseUrl + "database.php";
	public static string screenshotUrl = baseUrl + "screenshot.php";

	public static bool updateParameters = false;
	public static bool isInitialized = false;
	public static bool isPauseAllowed = true;
	
	

	public static void Pause(bool flag, bool icon = true) {
		if (isPauseAllowed) {
			isPaused = flag;
			if (isPaused) {
				playSound_last = playSound;
				playEffects_last = playEffects;
				playSound = false;
				playEffects = false;
				Time.timeScale = 0.0f;
				if (icon) {
					GameObject.Find ("Canvas/Pause").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
				}
			} else {
				playSound = playSound_last;
				playEffects = playEffects_last;
				Time.timeScale = 1.0f;
				if (icon) {
					GameObject.Find ("Canvas/Pause").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
				}
			}
		}
	}
}
