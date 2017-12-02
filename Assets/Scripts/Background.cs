using UnityEngine;

public class Background : MonoBehaviour {

	public float speed = 0.5f;

	private MeshRenderer meshRenderer;

	void Start () {
		meshRenderer = GetComponent<MeshRenderer> ();
	}
	
	void FixedUpdate () {
		Vector2 cameraPosition = Camera.main.transform.position;
		Vector2 offset = cameraPosition * speed;
		meshRenderer.material.mainTextureOffset = offset;
	}
}
