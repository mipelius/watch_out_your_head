using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public Transform head;

    public float headGrowthPerPickup;
    
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Coin"))
        {
            head.localScale += Vector3.one * headGrowthPerPickup;
            
            Destroy(collider.gameObject);
        }
    }
}
