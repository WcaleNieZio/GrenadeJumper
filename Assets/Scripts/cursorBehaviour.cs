using UnityEngine;
using System.Collections;

public class cursorBehaviour : MonoBehaviour {


	public Transform cursor;
	private Vector3 delta;

	public bool mouseVisible;
	public float mouseMaxDistance;
	public float mouseSensitive;

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
		
	void Update () {
		Cursor.visible = mouseVisible;
		cursorPosition ();
	}

	void cursorPosition(){
		delta = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0) * (mouseSensitive / 10);
		if(delta != Vector3.zero)
			cursor.localPosition = Vector3.ClampMagnitude ((new Vector3 (cursor.position.x, cursor.position.y, 0) + delta) - transform.position, mouseMaxDistance);
	}
}