using UnityEngine;

public class CheckpointPickup : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.CompareTag("Checkpoint"))
		{
			if (GetComponent<HeadCollision>().head.gameObject.activeSelf)
			{
				CheckPointManager.instance.currentCheckPoint = collider.transform.position;
			}
		}
	}
	
}
