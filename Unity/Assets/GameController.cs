using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	//control enemy spawning
	public int maxNumberOfEnemies = 3;
	public float secondsBetweenSpawn = 2;

	//Keep references to all enemies currently onscreen
	public List<GameObject> enemies;
	public GameObject[] enemyPrefabs;
	public GameObject[] spawnPoints;

	public ShootingController shootingController;

	//save the time when we are allowed to spawn a new enemy
	private float nextSpawnTime = 0.0f;

	public void searchNewTarget(GameObject exclude) {
		enemies.RemoveAll (GameObject => GameObject == null || GameObject == exclude);
		GameObject target = enemies[0];
		for (int i = 1; i < enemies.Count; i++) {
			if (enemies [i].transform.position.y < target.transform.position.y) {
				target = enemies [i];
			}
		}
		shootingController.target = target;
	}

	
	// Update is called once per frame
	void Update () {
		enemies.RemoveAll (GameObject => GameObject == null);
		//check if maximum number is already onscreen
		//and debounce spawning
		//always spawn if only one enemy left
		if ((enemies.Count < maxNumberOfEnemies && nextSpawnTime < Time.time) || enemies.Count < 2) {
			GameObject prefab = enemyPrefabs [Random.Range(0, enemyPrefabs.Length)];
			Transform spawn = spawnPoints [Random.Range(0, spawnPoints.Length)].transform;
			GameObject newEnemy = Instantiate (prefab, spawn.position, spawn.rotation);
			enemies.Add (newEnemy);
			nextSpawnTime = Time.time + secondsBetweenSpawn;
		}
	}
}
