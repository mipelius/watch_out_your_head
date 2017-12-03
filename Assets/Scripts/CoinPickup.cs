using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public Transform head;

    public AudioClip coinPickupClip;

    public float headGrowthPerPickup;
    
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Coin"))
        {
            head.localScale += Vector3.one * headGrowthPerPickup;

            AudioManager.instance.PlaySingle(coinPickupClip, 0.5f);
            
            Destroy(collider.gameObject);
        }
    }
}
