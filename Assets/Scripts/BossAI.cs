using UnityEngine;

public class BossAI : MonoBehaviour
{
	public GameObject throwableCoinPrefab;
	
	public float coinThrowInterval = 0.5f;

	public float kickForce = 2000f;
	
	public float throwForce = 1000f;

	public float anticipation = 20f;
	
	private float coinThrowTimestamp;

	public Transform target;
	
	void Start()
	{
		coinThrowTimestamp = Time.time;
	}
	
	void Update () {
		if (Time.time - coinThrowTimestamp > coinThrowInterval)
		{
			coinThrowTimestamp = Time.time;
			
			GameObject coin = Instantiate(
				throwableCoinPrefab, 
				transform.position + new Vector3(0f, 2f, -3f), 
				Quaternion.identity
			);

			var targetRb = target.GetComponent<Rigidbody2D>();
			var coinRb = coin.GetComponent<Rigidbody2D>();			

			Vector3 throwTarget = targetRb.position + targetRb.velocity * Time.deltaTime * anticipation;
			throwTarget.z = 1;
			
			coinRb.AddForce(
				(throwTarget - transform.position).normalized * throwForce
			);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log(collision.collider.tag);
		if (
			collision.collider.CompareTag("Player") 	|| 
			collision.collider.CompareTag("PlayerHead")
		)
		{	
			GameObject obj = collision.gameObject;
			var rb = obj.GetComponent<Rigidbody2D>();
			rb.AddForce(
				new Vector2(Mathf.Sign(obj.transform.position.x - transform.position.x) * kickForce, 0)
			);
		}
	}
}
