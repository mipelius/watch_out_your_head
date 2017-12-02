using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
	void Awake ()
	{
		#if !UNITY_EDITOR
			SceneManager.LoadScene(1);
		#endif		
	}
}
