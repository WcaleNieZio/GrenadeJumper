using UnityEngine;
using System.Collections;

public class cursorBehaviour : MonoBehaviour {

	public float cursorRadius;
	public float limitRadius;
	public Transform cursor;

	// Use this for initialization
	void Start () {
		limitRadius -= cursorRadius;
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update () {
		LimitMouseDistance ();
	}

	void LimitMouseDistance(){

		Vector2 playerPos = transform.position;

		float mousePosX = Camera.main.ScreenToWorldPoint (Input.mousePosition).x - playerPos.x;
		float mousePosY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y - playerPos.y;

		Vector3 tempPosition = new Vector2 (mousePosX, mousePosY);
		if (tempPosition.magnitude > 0) {
			//tempPosition = ((tempPosition.normalized * limitRadius) + transform.position); 
			if(tempPosition.magnitude < limitRadius)
				tempPosition = tempPosition + transform.position;
			else
				tempPosition = ((tempPosition.normalized * limitRadius) + transform.position); 
		}
		cursor.position = tempPosition;
	}
}
