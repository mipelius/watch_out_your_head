using UnityEngine;

public class Money : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Coin")) {
            Debug.Log("Player picked up a coin.");
            Destroy(collider.gameObject);
        }
    }
}
