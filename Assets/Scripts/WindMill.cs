using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill : MonoBehaviour
{
	private Rigidbody2D rb;

	public float angularVelocity;
	
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		rb.angularVelocity = angularVelocity;
	}
}
