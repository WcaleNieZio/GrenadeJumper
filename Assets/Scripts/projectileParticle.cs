using UnityEngine;
using System.Collections;

public class projectileParticle : MonoBehaviour {

	public Transform collisionCheck;
	public float collisionCheckRadius;
	public LayerMask whatIsCollider;
	public bool collision;

	GameObject projectileParticles;
	public ParticleSystem particles;
	private float _destroyTime = 1;


	void Start () {

		collision = false;
		projectileParticles = (gameObject) as GameObject;
		particles = GetComponent<ParticleSystem>();

	}


	void Update () {

		collision = Physics2D.OverlapCircle (collisionCheck.position, collisionCheckRadius, whatIsCollider);
			
		if (collision) { //Tu zatrzymujemy animacje czasteczek lecacych za granatem

			particles.Stop ();
			Destroy (projectileParticles, _destroyTime);

		}
	}
}