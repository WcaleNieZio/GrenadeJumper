using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float playerSpeed;
	public float maxSpeed;
	public Rigidbody2D player;
	public Transform playerTransform;

	public Transform leftLockTransformTop;
	public Transform leftLockTransformBottom;
	public Transform rightLockTransformTop;
	public Transform rightLockTransformBottom;
	public LayerMask whatIsGround;
	public float lockRadius;

	public bool lockLeftSideTop;
	public bool lockRightSideTop;
	public bool lockLeftSideBottom;
	public bool lockRightSideBottom;

	public float velocityLocker;

	public Vector2 spawnPosition;

	public BoxCollider2D antiLandingGlitchBottom;
	public bool isTouchingGround;


	void Start () {
	
		player = GetComponent<Rigidbody2D> ();
		playerTransform = GetComponent<Transform> ();

	}
	

	void FixedUpdate () {

		lockLeftSideTop = Physics2D.OverlapCircle(leftLockTransformTop.position, lockRadius, whatIsGround);
		lockRightSideTop = Physics2D.OverlapCircle(rightLockTransformTop.position, lockRadius, whatIsGround);
		lockLeftSideBottom = Physics2D.OverlapCircle(leftLockTransformBottom.position, lockRadius, whatIsGround);
		lockRightSideBottom = Physics2D.OverlapCircle(rightLockTransformBottom.position, lockRadius, whatIsGround);
		
		// move left
		if (Input.GetKey (KeyCode.A) && player.velocity.x>-maxSpeed && !lockLeftSideTop && !lockLeftSideBottom) {

			player.AddForce (new Vector2 (-playerSpeed, 0));
			
		}
		// move right
		if (Input.GetKey (KeyCode.D) && player.velocity.x < maxSpeed && !lockRightSideTop && !lockRightSideBottom) {

			player.AddForce (new Vector2 (playerSpeed, 0));

		}
		// player respawn
		if (Input.GetKeyDown (KeyCode.R)) {
			
			playerTransform.position = spawnPosition;
			player.velocity = new Vector2 (0, 0);

		}

		// clamp velocity
		player.velocity = new Vector2(Mathf.Clamp(player.velocity.x, -1 * velocityLocker, velocityLocker), Mathf.Clamp(player.velocity.y, -1 * velocityLocker, velocityLocker));

		//Debug.Log (player.velocity.y);

		//antiLandingGlitch

		/*if (antiLandingGlitchBottom.IsTouchingLayers (whatIsGround))
			playerTransform.position = new Vector2 (playerTransform.position.x, Mathf.Clamp (playerTransform.position.y, Mathf.CeilToInt (playerTransform.position.y) - 0.5f, playerTransform.position.y + 5));

		Debug.Log (Mathf.CeilToInt (playerTransform.position.y) - .5f);*/
	}
}
