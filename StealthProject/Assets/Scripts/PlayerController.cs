using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int life = 1;
	public float velStart;
	private float vel;
	public bool canMove = true;


	public Transform gun;
	public SpriteRenderer playerSprite;
	
	[SerializeField] private Animator animator;

	float moveY;
	float moveX;

	void Start () {
		animator = GetComponent<Animator> ();
		playerSprite = GetComponent<SpriteRenderer>();
		vel = velStart;
	}
	
	void FixedUpdate () {
		gun.transform.right = (MouseCursor.cursorPos - transform.position); //look to the mouse positions

		//Picking Movement Inputs into Float
		moveY = Input.GetAxisRaw ("Vertical");
		moveX = Input.GetAxisRaw ("Horizontal");

		//Movement condition
		if (canMove) {
			Vector2 movement = new Vector2 (moveX, moveY);

			if (movement.magnitude > 1) 
				movement = movement.normalized;

            if (movement != Vector2.zero)
            {
				Move(movement);
            }
            else
            {
				animator.Play("Idle");
			}

		}

		if (MouseCursor.cursorPos.x > transform.position.x + 1f)
		{
			transform.localScale = new Vector3(1, 1, 0);
			gun.localScale = new Vector3(1, 1, 0);
		}
		if (MouseCursor.cursorPos.x < transform.position.x - 1f)
		{
			transform.localScale = new Vector3(-1, 1, 0);
			gun.localScale = new Vector3(-1, -1, 0);
		}
	}
    private void Move(Vector2 _movement)
    {
		transform.Translate(_movement * vel * Time.deltaTime, Space.World);
		animator.Play("Run");
        
	}
    void Update(){
		

		
	}
		
}
