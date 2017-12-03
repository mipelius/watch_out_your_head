using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectActivator : MonoBehaviour
{
	public GameObject[] objectsToActivate;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (
			collider.CompareTag("Player")	 ||
			collider.CompareTag("PlayerHead")
		)
		{
			foreach (var obj in objectsToActivate) {
				obj.SetActive(true);
			}
			Destroy(gameObject);
		}
	}
}
