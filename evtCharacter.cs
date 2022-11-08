using UnityEngine;
using System.Collections;



public class evtCharacter : MonoBehaviour {
	private Animator anim;
	
	private bool grounded;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private float groundRadius;
	
	private bool faithOn;
	private float vitesse;
	private float maxSpeed;
	private float jumpForce;
	private bool doubleJump;

	public float vitesseInit = 1f;
	public float maxSpeedInit = 2f;
	public float faithValue = 0.05f;
	public float jumpForceInit = 150f;
	public bool doubleJumpAllowed = true;


	private string characterName;
	


	// Use this for initialization
	void Start () {
		faithOn = false;
		grounded = false;
		doubleJump = false;
		groundRadius = 0.2f;

		vitesse = vitesseInit;
		maxSpeed = maxSpeedInit;
		anim = GetComponent<Animator>();
		characterName = evtWorld.getMainCharacterObjectName();
	}
	
	
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!faithOn) {
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
			anim.SetBool("Ground", grounded);
			anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
			
			if (grounded)
				doubleJump = false;
				
			if (!grounded)
				return;
				
			float move = Input.GetAxis("Horizontal");
			anim.SetFloat("Speed", Mathf.Abs(move));
			GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed * vitesse, GetComponent<Rigidbody2D>().velocity.y);


			if (move > 0) 
				anim.SetBool("facingRight", true);
			else if (move < 0)
				anim.SetBool("facingRight", false);
		} else {
			anim.SetFloat("Speed", 0.0f);
		}
	}
	void Update() {		//for better input accuracy
		if (!faithOn) {
			vitesse = vitesseInit;
			jumpForce = jumpForceInit;
			for (int c = 1; c <= evtWorld.ideas; c++) {
				if (c % 2 == 1) {
					jumpForce -= jumpForce / 3f;
				} else {
					vitesse /= 2f;
				}
			}
			
			if ( (grounded || (!doubleJump && doubleJumpAllowed) ) && staticControls.isJumpButtonDown() && Time.timeScale != 0.0f) {
				anim.SetBool("Ground", false);
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
				
				if (staticBehaviour.playEffects) 
					GameObject.Find("Bruitages/Jump").GetComponent<AudioSource>().Play();
					
				if (!doubleJump && !grounded)
					doubleJump = true;
			}
		}
	}



	public string getCharacterName() {
		return characterName;
	}
	public Animator getAnimator() {
		return anim;
	}
	public float getFaithValue() {
		return faithValue;
	}
	public bool isOnFaith() {
		return faithOn;
	}



	public void setFaith(bool flag) {
		faithOn = flag;
	}
}
