
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;

	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;

	public AudioClip TODO_REMOVE; // TODO
	
	void Awake ()
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			jump = true;
		}
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(h));
		
		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce(Vector2.right * h * moveForce);

		if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
		{
			rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}
		
		if (h > 0 && !facingRight)
			Flip();
		else if (h < 0 && facingRight)
		{
			Flip();
		}

		if (jump)
		{
			AudioManager.instance.PlaySingle(TODO_REMOVE); // TODO
			
			anim.SetTrigger("Jump");
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
