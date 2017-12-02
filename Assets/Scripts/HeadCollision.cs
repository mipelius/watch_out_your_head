using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadCollision : MonoBehaviour
{
    public GameObject head;
    public GameObject bloodBurstPrefab;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (
            collision.collider.CompareTag("Ground") &&
            collision.otherCollider.CompareTag("PlayerHead")
        )
        {
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
