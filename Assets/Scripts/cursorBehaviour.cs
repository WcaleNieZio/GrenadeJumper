using UnityEngine;
using System.Collections;

public class cursorBehaviour : MonoBehaviour {

	public float limitRadius;
	public Transform cursor;

	private Vector3 lastMousePosition;
	private Vector3 delta;


	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}

	// Update is called once per frame4
	void Update () {
		cursorPosition ();
	}

	void cursorPosition(){

		if (lastMousePosition != Input.mousePosition) {
			delta = (Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position) - (Camera.main.ScreenToWorldPoint (lastMousePosition) - transform.position);
			cursor.localPosition = Vector3.ClampMagnitude ((new Vector3 (cursor.position.x, cursor.position.y, 0) + delta) - transform.position, limitRadius);
		}

		lastMousePosition = Input.mousePosition;
	}
}