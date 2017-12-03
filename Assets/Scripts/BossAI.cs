using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAI : MonoBehaviour
{
	public GameObject throwableCoinPrefab;

	public int coins = 20;
	
	public float coinThrowInterval = 0.5f;
	public float kickForce = 2000f;
	public float throwForce = 1000f;
	public float anticipation = 20f;

	public int explodeCoins = 40;
	public int explodeCoinsMultiplier = 5;
	
	private float coinThrowTimestamp;

	private const float victoryDelay = 2.0f;
	
	public Transform target;
	
	void Start()
	{
		coinThrowTimestamp = Time.time;
	}
	
	void Update () {
		if (
			coins > 0 &&
			Time.time - coinThrowTimestamp > coinThrowInterval
		)
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

			coins--;
		}
		
		if (coins <= 0)
		{
			for (int i = 0; i < explodeCoinsMultiplier; i++)
			{
				CoinBurst(explodeCoins, 1.0f + i);		
			}
			
			gameObject.SetActive(false);
			
			Invoke("Victory", 2.0f);
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

	private void Victory()
	{
		if (target.GetComponent<HeadCollision>().head.gameObject.activeSelf)
		{
			SceneManager.LoadScene("VictoryScreen");
		}
	}

	private void CoinBurst(int coins, float distanceFromPivot)
	{
		for (int i = 0; i < coins; i++)
		{
			float angle = (i * 2 * Mathf.PI) / coins;

			var direction = new Vector3(
				Mathf.Cos(angle), Mathf.Sin(angle), 0
			);

			GameObject coin = Instantiate(
				throwableCoinPrefab,
				transform.position + direction * distanceFromPivot, 
				Quaternion.identity
			);
				
			var coinRb = coin.GetComponent<Rigidbody2D>();

			coinRb.AddForce(direction * throwForce);				
		}
	}
}
