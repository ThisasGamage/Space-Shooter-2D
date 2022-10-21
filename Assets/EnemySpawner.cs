using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	float spawnDistance = 12f;

	float enemyRate = 5;
	float nextEnemy = 1;

	// Update is called once per frame
	void Update () {
		//Enemy respawn time
		nextEnemy -= Time.deltaTime;

		if(nextEnemy <= 0) {
			nextEnemy = enemyRate;
			//Changing respawn rate
			enemyRate *= 0.9f;
			if(enemyRate < 2)
				enemyRate = 2;

			//Randomizing spawn
			Vector3 offset = Random.onUnitSphere;

			offset.z = 0;

			offset = offset.normalized * spawnDistance;

			Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
		}
	}
}
