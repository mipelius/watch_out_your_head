using UnityEngine;

public class MoneyManAI : MonoBehaviour
{
	public Transform target;

	public float jumpInterval = 1.0f;

	public float jumpProbability;
		
	private CharacterMovement movement;

	private float lastJumpTimestamp;
	
	void Awake()
	{
		movement = GetComponent<CharacterMovement>();
		lastJumpTimestamp = Time.time;
	}

	void FixedUpdate()
	{
		movement.horizontalMovement = Mathf.Sign(target.position.x - transform.position.x);		
	}

	void Update()
	{
		if (Time.time - lastJumpTimestamp > jumpInterval)
		{
			lastJumpTimestamp = Time.time;
			
			if (Random.Range(0f, 1f) < jumpProbability)
			{
				movement.Jump();
			}
		}
	}
}
