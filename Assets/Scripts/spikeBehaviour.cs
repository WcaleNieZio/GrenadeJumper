using UnityEngine;
using System.Collections;

public class spikeBehaviour : MonoBehaviour {

	public Transform playerTransform;
	public Rigidbody2D playerRigidbody;
	public Collider2D playerCollider;
	GameObject deathParticle;
	float destroyTime = 0;
	public float deathCamTime;
	public SpriteRenderer playerSprite;

	public GameObject playerCamera;
	public GameObject playerWeapon;

	bool spikeTouched = false;
	bool particlePlayed = false;
	int i;

	void Update () {
	
		if (gameObject.GetComponent<Collider2D> ().IsTouching (playerCollider) || spikeTouched) {

			spikeTouched = true;
			playerRigidbody.velocity = new Vector2 (0, 0);
			playerRigidbody.isKinematic = true;
			destroyTime = destroyTime + Time.deltaTime;
			playerSprite.color = new Vector4 (0, 1, 1, 0);
			playerWeapon.SetActive(false);
			if (!particlePlayed) {
				for (i = 0; i < 1; i++){
					deathParticle = (GameObject)Instantiate (Resources.Load ("playerDeathParticle") as GameObject, new Vector3(playerTransform.position.x, playerTransform.position.y, -1), Quaternion.identity);
				particlePlayed = true;
				//deathParticle.GetComponentInChildren<ParticleSystem> ().Stop ();
				}
			}

			if (deathCamTime < destroyTime) {
				
				destroyTime = 0;
				playerTransform.position = new Vector2 (18, 4);
				playerRigidbody.isKinematic = false;
				spikeTouched = false;
				particlePlayed = false;
				playerSprite.color = new Vector4 (0, 1, 1, 1);
				playerWeapon.SetActive (true);
				Destroy (deathParticle, 0);

			}
		}
	}
}
