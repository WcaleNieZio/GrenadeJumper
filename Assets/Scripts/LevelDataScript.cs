using UnityEngine;
using System.Collections;

public class LevelDataScript : MonoBehaviour {

	public Vector2 spawnPoint;
	public Vector2[] checkPoint;
	public int checkPointIndex;

	public Transform respawnPointAnim;
	public Transform checkPointObject;

	public float playerGravity;
	float playerGravityConstant = 2;
	bool checkPointTouched;
	bool checkPointSwitch;
	public LayerMask whatIsPlayer;

	void Start () {

		checkPointIndex = 0;
		checkPointTouched = Physics2D.OverlapCircle (checkPointObject.position, 1, whatIsPlayer);
		respawnPointAnim.position = spawnPoint;
		checkPointObject.localPosition = checkPoint[checkPointIndex];
	
	}
	void Update () {
	
		checkPointTouched = Physics2D.OverlapCircle (checkPointObject.position, 1, whatIsPlayer);
		respawnPointAnim.position = spawnPoint;



		if (checkPointTouched) {
			for (int i = 1; i > 0; i--) {
				spawnPoint = checkPoint [checkPointIndex];
				checkPointIndex = checkPointIndex + 1;
				checkPointObject.localPosition = checkPoint[checkPointIndex];
			}
			checkPointTouched = false;
		}
	}
}
