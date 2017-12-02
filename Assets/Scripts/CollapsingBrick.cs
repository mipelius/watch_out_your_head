using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class CollapsingBrick : MonoBehaviour {
	public float fallDelay = 1.0f;
	public float mass = 1000f;
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (
			collision.collider.CompareTag("Player") ||
		    collision.collider.CompareTag("PlayerHead")
		)
		{
			Invoke("Fall", fallDelay);
		}
	}

	private void Fall()
	{
		var rb = GetComponent<Rigidbody2D>();
		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.mass = mass;
	}
}
