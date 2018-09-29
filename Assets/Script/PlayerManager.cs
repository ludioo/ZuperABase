using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public float speedX;
	public float jumpSpeedY;
	
	bool facingRight, Jumping;
	float speed;

	//Animator anim;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();
		//anim = GetComponent<Animator>();
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Player Movement
		MovePlayer(speed);
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			speed = -speedX;
		}

		if(Input.GetKeyUp(KeyCode.LeftArrow))
		{
			speed = 0;
		}

		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			speed = speedX;
		}

		if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			speed = 0;
		}

		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			Jumping = true;
			rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
			//anim.SetInteger("State",3);
		}
		
		Flip();
	}
	
	void MovePlayer(float playerSpeed)
	{
		if(playerSpeed < 0 && !Jumping || playerSpeed > 0 && !Jumping)
		{
			//anim.SetInteger("State",2);
		}

		if(playerSpeed == 0 && !Jumping)
		{
			//anim.SetInteger("State",0);
		}

		rb.velocity = new Vector3(speed, rb.velocity.y,0);


	}

	void Flip()
	{
		if(speed > 0 && !facingRight || speed < 0 && facingRight)
		{
			facingRight = !facingRight;

			Vector3 temp = transform.localScale;
			temp.x *= -1;
			transform.localScale = temp;

			//transform.localScale.x = -transform.localScale.x;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Ground")
		{
			Jumping = false;
			//anim.SetInteger("State",0);
		}
		
	}

	public void WalkLeft()
	{
		speed = -speedX;
	}

	public void WalkRight()
	{
		speed = speedX;
	}

	public void StopMoving()
	{
		speed = 0;
	}

	public void Jump()
	{
		Jumping = true;
		rb.AddForce(new Vector2(rb.velocity.x, jumpSpeedY));
		//anim.SetInteger("State",3)
	}
}
