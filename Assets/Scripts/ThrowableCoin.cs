using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableCoin : MonoBehaviour
{
	public float aliveSeconds = 2.0f;
	
	private float startTimeStamp;
	
	void Start ()
	{
		startTimeStamp = Time.time;
	}
	
	void Update () {
		if (Time.time - startTimeStamp > aliveSeconds)
		{
			Destroy(gameObject);
		}	
	}
}
