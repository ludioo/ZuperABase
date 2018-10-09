using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
