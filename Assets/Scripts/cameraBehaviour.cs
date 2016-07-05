using UnityEngine;
using System.Collections;

public class cameraBehaviour : MonoBehaviour {

	public float cameraOffsetX;
	public float cameraOffsetY;
	public float cameraResizeX;
	public float cameraResizeY;
	public Rigidbody2D playerSource;
	public Transform cameraTransform;


	void Start () {
	
		//playerSource = GetComponent<Rigidbody2D> ();
		cameraTransform = GetComponent<Transform> ();

	}

	void Update () {

		cameraTransform.localPosition = new Vector3 (
			playerSource.velocity.x * cameraOffsetX,
			playerSource.velocity.y * cameraOffsetY,
			cameraTransform.localPosition.z
		);

		cameraTransform.localScale = new Vector3 (
			playerSource.velocity.x * cameraResizeX,
			playerSource.velocity.y * cameraResizeY,
			cameraTransform.localPosition.z
		);
	}
}
