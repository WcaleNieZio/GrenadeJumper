using UnityEngine;
using System.Collections;

public class cloudGenerator : MonoBehaviour {

	public Transform playerTransform;
	public float spawnRatio;
	public float cloudLifetime;
	public float cloudSpeed;
	float randomizer;
	float timeCooldown;

	GameObject cloud1;
	GameObject cloud2;
	GameObject cloud3;

	GameObject cloud1Prefab;
	GameObject cloud2Prefab;
	GameObject cloud3Prefab;


	void Start () {
	
		cloud1 = Resources.Load ("Cloud1") as GameObject;
		cloud2 = Resources.Load ("Cloud2") as GameObject;
		cloud3 = Resources.Load ("Cloud3") as GameObject;

	}
	void Update () {

		timeCooldown = timeCooldown + Time.deltaTime;

		if (timeCooldown > spawnRatio){
			
			timeCooldown = 0;
			randomizer = Random.Range (0, 2);

		}

		//Debug.Log (timeCooldown);
	
		if (randomizer == 0 && timeCooldown == 0) {
			
			cloud1Prefab = (GameObject)Instantiate (cloud1, new Vector3 (playerTransform.position.x + 25, -50 + 100 * Mathf.Pow(10*Time.deltaTime, Random.value), 30), Quaternion.identity);
			cloud1Prefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-cloudSpeed - 2 * Random.value, 0);
			Destroy (cloud1Prefab, cloudLifetime);

		}
		if (randomizer == 1 && randomizer < 1.99f && timeCooldown == 0) {
			
			cloud2Prefab = (GameObject)Instantiate (cloud2, new Vector3 (playerTransform.position.x + 25, -50 + 100 * Mathf.Pow(10*Time.deltaTime, Random.value), 30), Quaternion.identity);
			cloud2Prefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-cloudSpeed - 2 * Random.value, 0);
			Destroy (cloud2Prefab, cloudLifetime);

		}
		if (randomizer == 2 && randomizer < 3 && timeCooldown == 0) {
			
			cloud3Prefab = (GameObject)Instantiate (cloud3, new Vector3 (playerTransform.position.x + 25, -50 + 100 * Mathf.Pow(10*Time.deltaTime, Random.value), 30), Quaternion.identity);
			cloud3Prefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-cloudSpeed - 2 * Random.value, 0);
			Destroy (cloud3Prefab, cloudLifetime);

		}
	}
}
