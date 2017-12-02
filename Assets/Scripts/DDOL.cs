using UnityEngine;

public class DDOL : MonoBehaviour {
	void Awake () {		
		DontDestroyOnLoad (gameObject);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
