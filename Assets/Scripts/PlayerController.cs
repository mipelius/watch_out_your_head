
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private CharacterMovement characterMovement;
	
	void Awake ()
	{
		characterMovement = GetComponent<CharacterMovement>();
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			characterMovement.Jump();
		}
	}

	void FixedUpdate()
	{
		characterMovement.horizontalMovement = Input.GetAxis("Horizontal"); 
	}
	
}
