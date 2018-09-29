using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float speed = 5f;
    private float jumpForce = 400f;
    private bool grounded;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer ren;

	// Use this for initialization
	void Start () {
        ren = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grounded = true;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(grounded);
	}
    
    public void Jump()
    {
        if(grounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
            
    }

    public void MoveLeft()
    {
        Debug.Log("PLAYER MOVE LEFT");
        ren.flipX = true;
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    }

    public void MoveRight()
    {
        Debug.Log("PLAYER MOVE RIGHT");
        ren.flipX = false;
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Coins")
        {
            GameManager.instance.coins++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
