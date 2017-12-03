using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadCollision : MonoBehaviour
{
    public GameObject head;
    public GameObject bloodBurstPrefab;

    public AudioClip headExplosionClip;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (
            collision.collider.CompareTag("Ground") &&
            collision.otherCollider.CompareTag("PlayerHead")
        )
        {
            AudioManager.instance.PlaySingle(headExplosionClip);
            
            head.SetActive(false);
            Instantiate(
                bloodBurstPrefab, 
                head.transform.position, 
                Quaternion.identity
            );
            
            Invoke("Restart", 2.0f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
