using UnityEngine;

public class BloodBurst : MonoBehaviour
{
	private ParticleSystem particleSystem;
	
	void Awake()
	{
		particleSystem = GetComponent<ParticleSystem>();		
	}
	
	void Update () {
		if (particleSystem.isStopped)
		{
			Destroy(gameObject);
		}	
	}
}
