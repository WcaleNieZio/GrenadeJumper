using UnityEngine;
using System.Collections;

public class projectileExplosion : MonoBehaviour {

	public ParticleSystem particle1;
	public ParticleSystem particle2;
	public ParticleSystem particle3;
	GameObject explosion;
	private float explosionTime=1;

	void Start () {

		explosion = (gameObject) as GameObject;

		//particle1.Play ();
		//particle2.Play ();
		//particle3.Play ();
		Destroy (explosion, explosionTime);
	}
}
