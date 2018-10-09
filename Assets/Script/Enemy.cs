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

	// Use this for initialization
	void Start () {
        initialPosition = transform.position;
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
                    rb.velocity = new Vector2(enemySpeed, 0);
                }
                else
                {
                    direction = -1;
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Hcl")
		{
			Destroy(gameObject);
			Destroy(collision.gameObject);
		}
		if(collision.gameObject.tag == "c2h2o4")
		{
			Destroy(collision.gameObject);
		}
		if(collision.gameObject.tag == "c6h8o7")
		{
			Destroy(collision.gameObject);
		}
	}
}
