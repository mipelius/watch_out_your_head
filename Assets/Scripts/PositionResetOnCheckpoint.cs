using UnityEngine;

public class PositionResetOnCheckpoint : MonoBehaviour {
    public Transform checkpoint;
    public Vector3 positionToSet;
    
	void Awake () {
		if (CheckPointManager.instance.checkPointIsSet(checkpoint.position))
		{
			transform.position = positionToSet;
		}
	}
}
