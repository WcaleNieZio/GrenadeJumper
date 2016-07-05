using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {

	public Transform explosionPoint;
	public LayerMask whatIsPlayer;
	public float explosionRadius;

	public bool playerInRange;

	private float destroyTime = 0.1f;

	public Rigidbody2D playerRigid;


	void Start () {

		playerInRange = Physics2D.OverlapCircle (explosionPoint.position, explosionRadius, whatIsPlayer);
		playerRigid = GetComponent<Rigidbody2D> ();

		if (playerInRange) {

			playerRigid.AddRelativeForce (new Vector2 (0, 1), ForceMode2D.Impulse);


		}	

		Destroy (this, destroyTime);
	}
}
