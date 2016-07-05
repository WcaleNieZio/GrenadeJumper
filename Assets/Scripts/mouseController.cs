using UnityEngine;
using System.Collections;

public class mouseController : MonoBehaviour {

	public enum SpriteRotation {

		Up = -90,
		Right = 0,
		Down = 90,
		Left = 180
	}

	public Camera currentCamera;
	public SpriteRotation initialRotation;

	private Vector2 _direction;
	private Vector2 _mousePosition;
	private Transform _transform;

	private float _angle;

	GameObject prefab;
	GameObject prefab2;
	public float projectileSpeed;
	public Rigidbody2D player;
	public float projectileLifetime;
	public float projectileParticlesLifetime;

	public float shootCooldown;
	public float cooldownTime;

	public Camera mainCamera;
	public AudioSource shootingSound;
	public AudioReverbZone cameraReverb;

	void Start () {

		prefab = Resources.Load ("projectile") as GameObject;
		prefab2 = Resources.Load ("projectileParticle") as GameObject;

		_transform = transform;

		if (!currentCamera)
			currentCamera = Camera.main;
	
	}
	

	void Update () {

		// Tu pobieramy pozycje kursora
		_mousePosition = currentCamera.ScreenToWorldPoint (Input.mousePosition);
		_direction = (_mousePosition - (Vector2)_transform.position).normalized;

		_angle = Mathf.Atan2 (_direction.y, _direction.x) * Mathf.Rad2Deg + (int)initialRotation;
		_transform.rotation = Quaternion.AngleAxis (_angle, Vector3.forward);

		// Tu strzelamy
		if (Input.GetMouseButtonDown (0) && shootCooldown == 0) {

			shootingSound.Play ();
			GameObject projectile = Instantiate (prefab) as GameObject; // Tu wywolujemy granat
			projectile.transform.position = player.transform.position;
			Rigidbody2D rb = projectile.GetComponent<Rigidbody2D> ();
			rb.velocity = _direction * projectileSpeed;
			Destroy (projectile.gameObject, projectileLifetime);

			GameObject projectileParticle = Instantiate (prefab2) as GameObject; // Tu wywolujemy czasteczki
			projectileParticle.transform.position = player.transform.position;
			Rigidbody2D rb2 = projectileParticle.GetComponent<Rigidbody2D> ();
			rb2.velocity = _direction * projectileSpeed;
			Destroy (projectileParticle.gameObject, projectileParticlesLifetime);
			shootCooldown = 0.1f;

		}
		if (shootCooldown > 0) {
			shootCooldown = shootCooldown + Time.fixedDeltaTime;
			if (shootCooldown > cooldownTime)
				shootCooldown = 0;
		}
		if (Input.GetMouseButton (2)) {
			
			mainCamera.orthographicSize = Mathf.Clamp (mainCamera.orthographicSize + Time.deltaTime * 10, 8, 15);
			cameraReverb.room = Mathf.Clamp (Mathf.FloorToInt(cameraReverb.room + Time.deltaTime * 20000), -10000, -1000);

		} else {
			
			mainCamera.orthographicSize = Mathf.Clamp (mainCamera.orthographicSize - Time.deltaTime * 10, 8, 15);
			cameraReverb.room = Mathf.Clamp (Mathf.FloorToInt(cameraReverb.room - Time.deltaTime * 20000), -10000, -1000);

		}
	}
}
