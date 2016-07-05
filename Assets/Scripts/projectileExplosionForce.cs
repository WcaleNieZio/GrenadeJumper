using UnityEngine;
using System.Collections;

public class projectileExplosionForce : MonoBehaviour {

	public Transform explosionPoint;
	public LayerMask whatIsPlayer;
	public float explosionRadius;

	public Collider2D playerInRange;

	private float destroyTime = 0.1f;

	public float explosionForce;

	public bool isExploded = true;

	void Start () {

		playerInRange = Physics2D.OverlapCircle (explosionPoint.position, explosionRadius, whatIsPlayer);

	}
	void FixedUpdate () {
		if (playerInRange && isExploded) {
		
			playerInRange.GetComponent<Rigidbody2D>().AddRelativeForce(
				(new Vector2(playerInRange.transform.position.x - explosionPoint.position.x, playerInRange.transform.position.y - explosionPoint.position.y).normalized * explosionForce / Vector2.Distance(playerInRange.transform.position, explosionPoint.position) ), 
				ForceMode2D.Impulse);

			isExploded = false;
		} 
		Destroy (this, destroyTime);
	}
}
