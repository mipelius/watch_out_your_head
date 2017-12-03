using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	private bool facingRight = true;
	private bool jump = false;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public float brakeForce = 10f;
	public Transform groundCheck;
	
	public bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;

	public float horizontalMovement;
	
	public bool Jump()
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		
		if (grounded) {
			jump = true;
			return true;
		}
		return false;
	}

	public void Brake()
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		
		//if (grounded)
		{
			if (Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon)
			{
				float brakeAmount = Mathf.Sign(rb2d.velocity.x) * brakeForce * Time.deltaTime;

				float velX;

				if (Mathf.Abs(rb2d.velocity.x) < Mathf.Abs(brakeAmount))
				{
					velX = 0f;
				}
				else
				{
					velX = rb2d.velocity.x - brakeAmount;
				}
				
				rb2d.velocity = new Vector2(velX, rb2d.velocity.y);
			}
		}
	}
	
	void Awake ()
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate()
	{
		if (horizontalMovement * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce(Vector2.right * horizontalMovement * moveForce);

		if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
		{
			rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}
		
		if (horizontalMovement > 0 && !facingRight)
			Flip();
		else if (horizontalMovement < 0 && facingRight)
		{
			Flip();
		}

		if (jump)
		{
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
