using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {
	private Rigidbody2D rb;

	public float liftingVelocity;
	public float mass;
	
	public float liftDelay;

	private bool activated = false;
	
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		if (activated)
		{
			rb.velocity = Vector2.up * liftingVelocity;			
		}		
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (
			collision.collider.CompareTag("Player") ||
			collision.collider.CompareTag("PlayerHead")
		)
		{
			Invoke("Activate", liftDelay);
		}
		
	}

	private void Activate()
	{
		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.mass = mass;
		activated = true;
	}
	
}
