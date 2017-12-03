
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public AudioClip jumpClip;

	private CharacterMovement characterMovement;
	
	void Awake ()
	{
		Cursor.visible = false;
		
		characterMovement = GetComponent<CharacterMovement>();
		if (CheckPointManager.instance.checkPointIsSet())
		{
			transform.position = CheckPointManager.instance.currentCheckPoint;
		}
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));			
		}
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (characterMovement.Jump())
			{
				AudioManager.instance.PlaySingle(jumpClip);
			}
		}
	}

	void FixedUpdate()
	{
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
