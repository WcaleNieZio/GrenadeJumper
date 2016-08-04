using UnityEngine;
using System.Collections;

public class cursorBehaviour : MonoBehaviour {

	public float limitRadius;
	public Transform cursor;
	private Vector3 delta;
	public bool mouseVisible;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame4
	void Update () {
		Cursor.visible = mouseVisible;
		cursorPosition ();
	}

	void cursorPosition(){
		delta = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
		if(delta != Vector3.zero)
			cursor.localPosition = Vector3.ClampMagnitude ((new Vector3 (cursor.position.x, cursor.position.y, 0) + delta) - transform.position, limitRadius);
	}
}