
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private CharacterMovement characterMovement;
	
	void Awake ()
	{
		characterMovement = GetComponent<CharacterMovement>();
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Z))
		{
			SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));			
		}
	
		// CHEAT
		
		if (Input.GetKeyDown(KeyCode.X))
		{
			transform.position = new Vector3(156f, 9.3f, 0f);
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			transform.position = new Vector3(77.1f, 70.2f, 0f);
		}
		if (Input.GetKeyDown(KeyCode.V))
		{			
			transform.position = new Vector3(-53.6f, 70.3f, 0f);
		}
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			characterMovement.Jump();
		}
	}

	void FixedUpdate()
	{
		//float h = Input.GetAxis("Horizontal");

		float h = 0;
		
		if (
			Input.GetKey(KeyCode.A) || 
			Input.GetKey(KeyCode.LeftArrow)
		)
		{
			h -= 1.0f;
		}
		if (
			Input.GetKey(KeyCode.D) || 
			Input.GetKey(KeyCode.RightArrow)
		)
		{
			h += 1.0f;
		}

		Debug.Log(h);
		
		characterMovement.horizontalMovement = h;
		
		if (Mathf.Abs(h) < Mathf.Epsilon) 
		{
			characterMovement.Brake();
		}		
	}	
}
