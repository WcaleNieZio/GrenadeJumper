using UnityEngine;
using System.Collections;

public class gunBehaviour : MonoBehaviour {

	public Transform myTransform;


	void Start () {
	
		myTransform = GetComponent<Transform> ();

	}

	void FixedUpdate () {


		if ((myTransform.eulerAngles.z > 90 && myTransform.eulerAngles.z < 270) && myTransform.localScale.y > 0) {
			myTransform.localScale = new Vector3 (
				myTransform.localScale.x,
				myTransform.localScale.y * -1,
				myTransform.localScale.z
			);
		}
		if ((myTransform.eulerAngles.z < 90 || myTransform.eulerAngles.z > 270) && myTransform.localScale.y < 0) {
			myTransform.localScale = new Vector3 (
				myTransform.localScale.x,
				myTransform.localScale.y * -1,
				myTransform.localScale.z
			);
		}
	}
}
