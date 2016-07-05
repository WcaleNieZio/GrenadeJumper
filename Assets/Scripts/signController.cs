using UnityEngine;
using System.Collections;

public class signController : MonoBehaviour {

	public Transform playerCheck;
	public LayerMask playerLayer;
	public float signRange;
	public TextMesh signText;

	public bool playerInRange;

	void Update () {
	
		playerInRange = Physics2D.OverlapCircle (playerCheck.position, signRange, playerLayer);

		if (playerInRange == true)
			signText.color = new Vector4 (signText.color.r, signText.color.g, signText.color.b, 1);
		else
			signText.color = new Vector4 (signText.color.r, signText.color.g, signText.color.b, 0);

	}
}
