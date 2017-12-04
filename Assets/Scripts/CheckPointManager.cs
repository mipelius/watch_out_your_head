using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour {
	public static CheckPointManager instance = null;

	void Awake () {
		if (instance == null) {
			instance = this;
			checkpoints = new List<Vector3>();
		} else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
	}
	
	public List<Vector3> checkpoints;

	public bool checkPointIsSet()
	{
		return checkpoints.Count > 0;
	}

	public bool checkPointIsSet(Vector3 position)
	{
		foreach (var checkpoint in checkpoints)
		{
			if ((checkpoint - position).magnitude < 0.1) 
				return true;
		}
		return false;
	}
	
	public Vector3 currentCheckPoint
	{
		get
		{
			return checkpoints[checkpoints.Count - 1]; 			
		}
		set
		{
			foreach (var checkpoint in checkpoints)
			{
				if ((checkpoint - value).magnitude < 0.1) 
					return;
			}
			
			checkpoints.Add(value);
		}
	}
	
	
	public void Reset()
	{
		checkpoints.Clear();
	}
}
