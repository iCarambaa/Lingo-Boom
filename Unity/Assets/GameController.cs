using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	//control enemy spawning
	public int maxNumberOfEnemies = 3;
	public int secondsBetweenSpawn = 2;

	//Keep references to all enemies currently onscreen
	public List<GameObject> enemies;
	public GameObject[] enemyPrefabs;
	public GameObject[] spawnPoints;

	//save the time when we are allowed to spawn a new enemy
	private float nextSpawnTime = 0.0f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//check if maximum number is already onscreen
		//and debounce spawning
		if (enemies.Count < maxNumberOfEnemies && nextSpawnTime < Time.time) {
			GameObject prefab = enemyPrefabs [Random.Range(0, enemyPrefabs.Length)];
			Transform spawn = spawnPoints [Random.Range(0, spawnPoints.Length)].transform;
			GameObject newEnemy = Instantiate (prefab, spawn.position, spawn.rotation);
			enemies.Add (newEnemy);
			nextSpawnTime = Time.time + secondsBetweenSpawn;
		}
	}
}
