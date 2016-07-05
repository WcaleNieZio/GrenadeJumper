using UnityEngine;
using System.Collections;

public class projectileExploder : MonoBehaviour {

	public Transform collisionCheck;
	public float collisionCheckRadius;
	public LayerMask whatIsCollider;
	public bool collision;

	private float _destroyTime = 0;
	GameObject projectile;
	GameObject explosionEffect;


	void Start () {

		collision = false;
		projectile = (gameObject) as GameObject;
		explosionEffect = Resources.Load ("projectileExplosion") as GameObject;

	
	}
	void FixedUpdate () {
	
		collision = Physics2D.OverlapCircle (collisionCheck.position, collisionCheckRadius, whatIsCollider);

		if (collision) { // Tutaj bedziemy rozwalac granat i wywolywac eksplozje

			GameObject projectileExplosion = Instantiate (explosionEffect) as GameObject; // Tutaj bedziemy rozwalac granat
			projectileExplosion.transform.position = projectile.transform.position;
			Destroy (projectile, _destroyTime);

		}
	}
}
