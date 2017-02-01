using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

	//control enemy spawning
	public float maxNumberOfEnemies = 3;
	public float startNumberOfEnemies = 1;
	private float currentNumberOfEnemies;

	public float minSecondsBetweenSpawn = 2;
	public float startSecondsBetweenSpawn = 3;
	private float currentSeccondsBetweenSpawn;

	public float startEnemySpeed = 0.5f;
	public float maxEnemySpeed = 3.0f;
	private float currentEnemySpeed;

	public float speedUpRate = 100.0f;
	//Keep references to all enemies currently onscreen
	public List<GameObject> enemies;
	public GameObject[] enemyPrefabs;
	public GameObject[] spawnPoints;

	public ShootingController shootingController;

	public GameObject gameOverScreen;
	public Text scoreLabel;

	private int score = 0;

	//save the time when we are allowed to spawn a new enemy
	private float nextSpawnTime = 0.0f;

	public void Start(){
		currentNumberOfEnemies = startNumberOfEnemies;
		currentSeccondsBetweenSpawn = startSecondsBetweenSpawn;
		currentEnemySpeed = startEnemySpeed;
		Application.targetFrameRate = 60;
	}

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

	public void assignPoints(int points){
		score += 1;
	}

	public void gameOver(){
		gameOverScreen.GetComponent<SpriteRenderer> ().enabled = true;
	}
	
	void Update () {
		scoreLabel.text = score.ToString();
		enemies.RemoveAll (GameObject => GameObject == null);
		//check if maximum number is already onscreen
		//and debounce spawning
		//always spawn if only one enemy left
		if ((enemies.Count < currentNumberOfEnemies && nextSpawnTime < Time.time) || enemies.Count < 2) {
			GameObject prefab = enemyPrefabs [Random.Range(0, enemyPrefabs.Length)];
			Transform spawn = spawnPoints [Random.Range(0, spawnPoints.Length)].transform;
			GameObject newEnemy = Instantiate (prefab, spawn.position, spawn.rotation);
			Enemy enemy = newEnemy.GetComponent<Enemy> ();
			enemy.speed = currentEnemySpeed;
			enemies.Add (newEnemy);
			nextSpawnTime = Time.time + currentSeccondsBetweenSpawn;
		}
		speedUp ();
	}

	private void speedUp(){
		currentEnemySpeed = Mathf.Lerp (startEnemySpeed, maxEnemySpeed, Time.time / speedUpRate);
		currentNumberOfEnemies = Mathf.Lerp (startNumberOfEnemies, maxNumberOfEnemies, Time.time / speedUpRate);
		currentSeccondsBetweenSpawn = Mathf.Lerp (startSecondsBetweenSpawn, minSecondsBetweenSpawn, Time.time / speedUpRate);
	}
}
