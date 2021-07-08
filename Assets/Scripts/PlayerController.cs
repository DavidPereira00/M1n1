using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float gtimer;
	public float stimer;
	public float jtimer;
	public float djtimer;
	//public Rigidbody theRB;
	public float jumpForce;
	public CharacterController controller;
	public LevelManager levelmanager;
	private Vector3 _inputs = Vector3.zero;
	public Vector3 moveDirection = Vector3.zero;
	public float gravityScale;
	public int jp;
	public int toff;
	public float gspeed;
	public float gravity;
	public float timer;
	private Animator animator;
	//public Projectile pr;
	private GameManager GM;
	public GameObject glide;
	private CollectGlide cg;
	private CollectDJump cdj;
	private CollectSprint cs;
	private CollectJump cj;
	public float jumpHeight = 0.0f;
	private bool grounded = false;
	public int d;
	private LevelManager lm;
	private Health h;
	public float lastpositionY = 0f;
	public float falldistance = 0f;
	public float time = 0f;
	public Vector3 targetPos;
	public int anim;
	public float timerr = 0f;

	public AudioSource jumpsound;
	public AudioSource doublejumpsound;
	public AudioSource jetpacksound;

	public GameObject smoke;
	public Transform cheat1;
	public Transform cheat2;
	public Transform cheat3;

	void Start () {
		//theRB = GetComponent<Rigidbody>();
		h = FindObjectOfType<Health>();
		lm = FindObjectOfType<LevelManager> ();
		GM=FindObjectOfType<GameManager>();
		cg = FindObjectOfType<CollectGlide> ();
		cdj = FindObjectOfType<CollectDJump> ();
		cs = FindObjectOfType<CollectSprint> ();
		cj = FindObjectOfType<CollectJump> ();
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		animator.SetBool("isonGround", true);
		jp = 0;
		gspeed = 0;
		gravity = -9.81f;
		timer = 0;
		toff = 0;
		anim = 0;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.B)) {
			transform.position = cheat1.position;
		}
		if (Input.GetKey (KeyCode.N)) {
			transform.position = cheat2.position;
		}
		if (Input.GetKey (KeyCode.M)) {
			transform.position = cheat3.position;
		}
		if (h.health <= 0) {
			lm.RespawnPlayer ();
		}
		/*if (pr.d == 1) {
			levelmanager.RespawnPlayer ();
		}*/
		//theRB.velocity = new Vector3 (Input.GetAxis ("Horizontal") * moveSpeed,theRB.velocity.y ,Input.GetAxis ("Vertical") * moveSpeed);

		//if(Input.GetButtonDown("Jump"))
		//{
			//theRB.velocity = new Vector3 (theRB.velocity.x, jumpForce, theRB.velocity.z);
		//}

	
		//moveDirection = new Vector3 (Input.GetAxis ("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis ("Vertical") * moveSpeed);
		float yStore = moveDirection.y;
		moveDirection = (transform.forward * Input.GetAxis ("Vertical")) + (transform.right * Input.GetAxis ("Horizontal"));
		moveDirection = moveDirection.normalized * moveSpeed;
		moveDirection.y = yStore;
		//Debug.Log (transform.position.y);


		_inputs = Vector3.zero;
		_inputs.x = Input.GetAxis("Horizontal");
		_inputs.z = Input.GetAxis("Vertical");
		if (Input.GetKey (KeyCode.A)) {
			animator.SetBool ("isLStrafe", true);
		} else {
			animator.SetBool ("isLStrafe", false);
		}
		if (Input.GetKey (KeyCode.D)) {
			animator.SetBool ("isRStrafe", true);
		} else {
			animator.SetBool ("isRStrafe", false);
		}
		if (controller.isGrounded && Input.GetAxis("Vertical")>0) { 
			animator.SetBool("isWalk", true);
		}
		else animator.SetBool("isWalk", false);
		/*
		if(Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") == 0) {
			//Play your sideways animation
			animation.Play("isWalk");
		}
		//If the player is moving vertically (forward and backward) or diagonally
		else {
			//Play your forward/backward animation
			animation.Play("Insert animation name here");
		}*/
		if (cg.glide == 1) {
			animator.SetBool ("isGItem", true);
			gtimer = gtimer + Time.deltaTime;
		}
		if (gtimer >= 0.9 ) {
			animator.SetBool ("isGItem", false);
		}
		if (cj.cjump == 1) {
			animator.SetBool ("isGItem", true);
			jtimer = jtimer + Time.deltaTime;
		}
		if (jtimer >= 0.9) {
			animator.SetBool ("isGItem", false);
		}
		if (cdj.djump == 1) {
			animator.SetBool ("isGItem", true);
			djtimer = djtimer + Time.deltaTime;
		}
		if (djtimer >= 0.9) {
			animator.SetBool ("isGItem", false);
		}
		if (cs.sprint == 1) {
			animator.SetBool ("isGItem", true);
			stimer = stimer + Time.deltaTime;
		}
		if (stimer >= 0.9) {
			animator.SetBool ("isGItem", false);
		}
		timerr = timerr + Time.deltaTime;
		if(controller.isGrounded && timerr >3) {
			animator.SetBool ("isonGround", true);
		}


		if (controller.isGrounded) {
			moveDirection.y = 0f;
		}

		if (controller.isGrounded && cj.cjump==1) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				moveDirection.y = jumpForce;
				jp = 1;
				timer = 0;
				toff = 0;
				anim = 1;
				animator.SetBool ("isonGround", false);
				jumpsound.Play ();
				//animator.SetBool ("isonGround", true);
			}
		}

		if (!controller.isGrounded && jp == 1) {
			if (Input.GetKeyDown (KeyCode.Space) && cdj.djump >= 1) {
				moveDirection.y = jumpForce;
				jp = 0;
				doublejumpsound.Play ();
			}
		}

		if (!controller.isGrounded && toff==0) {
			if (Input.GetKey (KeyCode.Z) && cg.glide >=1) {
				moveDirection.y = 0;
				gravity = 0;
				timer = timer + Time.deltaTime;
			}
		}
		if (!Input.GetKey (KeyCode.Z)&& cg.glide >=1) {
			gravity = -9.81f;
		}
		if (Input.GetKeyDown (KeyCode.Z) && cg.glide >= 1) {
			smoke.SetActive (true);
			jetpacksound.Play ();
		}
		if (Input.GetKeyUp (KeyCode.Z)) {
			smoke.SetActive (false);
			jetpacksound.Stop ();
		}
		if (timer >= 2) {
			gravity = -9.81f;
			toff = 1;
			smoke.SetActive (false);
			jetpacksound.Stop ();
		}
		time = Time.deltaTime;

		moveDirection.y = moveDirection.y + (gravity * gravityScale * time);
		controller.Move (moveDirection * Time.deltaTime);
		if (Input.GetKeyDown (KeyCode.LeftShift) && controller.isGrounded && cs.sprint >=1) {
			moveSpeed = moveSpeed + 3;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift) && controller.isGrounded && moveSpeed >= 6 && cs.sprint >=1) {
			moveSpeed = moveSpeed - 3;
		}
		//Debug.Log (transform.position.y);
	
	}

	public void TakeDamage(int amount){
		h.health -= amount;
	}

	/*
	void onTriggerEnter(Collider other){
		if (other.gameObject.tag == "Bullet") {
			levelmanager.RespawnPlayer ();
		}
	}*/
}
