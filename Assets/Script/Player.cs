using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private float speed = 5f;
    private float jumpForce = 400f;
    public static int curHealth = 5;
    private bool grounded;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer ren;

    
    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        ren = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grounded = true;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(grounded);
        if (curHealth <= 0)
        {
            GameManager.instance.coins = 0;
            GameManager.instance.soal = 0;
            curHealth = 5;
        }
            
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
        if (collision.gameObject.tag == "Laut")
        {
            curHealth-=2;
            transform.position = GameManager.instance.spawnPoint.transform.position;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            GameManager.instance.coins++;
            Destroy(collision.gameObject);
        }
    }
}
