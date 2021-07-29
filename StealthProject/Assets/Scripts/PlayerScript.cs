using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	private Vector3 target;
	private float angle;

	public float velStart;
	private float vel;
	public float impulse;
	public bool canMove;

	public float dashDelay;
	public float dashTime;
	private bool canDash = true;

	public Rigidbody2D rb;
	public Transform gun;
	public GameObject projectile;
	public GameObject bulletParticle;
	public GameObject dashTrail;
	public Animator shotAnim;

	float moveY;
	float moveX;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		vel = velStart;
	}
	
	void FixedUpdate () {
		//Picking mouse position
		target =  Camera.main.ScreenToWorldPoint(Input.mousePosition);	
		target.z = transform.position.z;
		transform.right = (target - transform.position); //look to the mouse positions

		//Picking Movement Inputs into Float
		float moveY = Input.GetAxis ("Vertical");
		float moveX = Input.GetAxis ("Horizontal");

		//Movement condition
		if (canMove){
			Vector2 moveForward = new Vector2 (moveY, -moveX);
			transform.Translate(moveForward * vel * Time.fixedDeltaTime);	
		}
		
			
			
		//Dash condition
		if (Input.GetButtonDown ("Jump")) {
			if (canDash) {
				canDash = false;
				Instantiate(dashTrail, transform.position, transform.rotation);
				StartCoroutine(DashTime());
				StartCoroutine (WaitToDash ());
			}
		}

		//Shooting
		if (Input.GetMouseButtonDown (0)) {
			Instantiate (projectile, gun.position, gun.rotation);
			Instantiate (bulletParticle, gun.position, gun.rotation);
		}
			
	}

	//Coroutine for Dash delay
	IEnumerator WaitToDash (){
		yield return new WaitForSeconds (dashDelay);
			canDash = true;
	}

	//Coroutine for Dash lenght
	IEnumerator DashTime (){
		rb.velocity = transform.right * impulse * Time.fixedDeltaTime;
		yield return new WaitForSeconds (dashTime);
		rb.velocity = Vector2.zero;
		
	}




	void OnCollisionEnter2D(Collision2D c){
		
			

	}
}
