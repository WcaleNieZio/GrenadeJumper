using UnityEngine;
using System.Collections;

public class projectileExplosionForce : MonoBehaviour {

	public Transform explosionPoint;
	public LayerMask whatIsPlayer;
	public float explosionRadius;

	public Collider2D playerInRange;

	private float destroyTime = 0.1f;

	public float explosionForce;


	void Start () {

		playerInRange = Physics2D.OverlapCircle (explosionPoint.position, explosionRadius, whatIsPlayer);

	}
	void FixedUpdate () {

			
		playerInRange.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (
			(playerInRange.transform.position.x - explosionPoint.transform.position.x) * Mathf.Pow (.5f, Mathf.Abs (playerInRange.transform.position.x - explosionPoint.transform.position.x)) * explosionForce, 
			(playerInRange.transform.position.y - explosionPoint.transform.position.y) * Mathf.Pow (.5f, Mathf.Abs (playerInRange.transform.position.y - explosionPoint.transform.position.y)) * explosionForce)
		, ForceMode2D.Impulse);

		Destroy (this, destroyTime);
	}
}
