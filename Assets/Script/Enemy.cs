using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody2D rb;
    private float enemySpeed = 3f;
    private float minDist;
    private float maxDist;
    private Vector2 initialPosition;
    private int direction;
    private SpriteRenderer ren;
    private Animator animator;

	// Use this for initialization
	void Start () {
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        ren = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        direction = -1;
        maxDist = transform.position.x + 2f;
        minDist = transform.position.x - 2f;
	}

    private void Update()
    {
        switch (direction)
        {
            case -1:
                if(transform.position.x > minDist)
                {
                    ren.flipX = false;
                    rb.velocity = new Vector2(-enemySpeed, 0);
                }
                else
                {
                    direction = 1;
                }
                break;
            case 1:
                if(transform.position.x < maxDist)
                {
                    ren.flipX = true;
                    rb.velocity = new Vector2(enemySpeed, 0);
                }
                else
                {
                    direction = -1;
                }
                break;
        }
    }

    public void MoveLeft()
    {
        ren.flipX = true;
        
        transform.Translate(new Vector3(-enemySpeed * Time.deltaTime, 0, 0));
    }

    public void MoveRight()
    {
        ren.flipX = false;
        transform.Translate(new Vector3(enemySpeed * Time.deltaTime, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Hcl")
		{
			Destroy(gameObject, 2f);
            enemySpeed = 0;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            animator.Play("Enemy_Happy");
			Destroy(collision.gameObject);
		}
		if(collision.gameObject.tag == "c2h2o4")
		{
            animator.Play("Enemy_Sad");
			Destroy(collision.gameObject);
		}
		if(collision.gameObject.tag == "c6h8o7")
		{
            animator.Play("Enemy_Sad");
			Destroy(collision.gameObject);
		}
	}
}
