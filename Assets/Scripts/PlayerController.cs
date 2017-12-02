
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private CharacterMovement characterMovement;
	
	void Awake ()
	{
		characterMovement = GetComponent<CharacterMovement>();
	}
	
	void Update ()
	{
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
