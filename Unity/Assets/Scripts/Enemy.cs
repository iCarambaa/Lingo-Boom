using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10.0f;
	public ShootingController shootingController;
	public GameController gameController;

	public void Start(){
		if (!shootingController) {
			shootingController = GameObject.Find ("ShootingController").GetComponent<ShootingController>();
		}
		if (!gameController) {
			gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		}
	}

	private void OnMouseDown() {
		shootingController.target = gameObject;
	}

	public void OnDestroy(){
		gameController.searchNewTarget (gameObject);
	}

	void Update() {
		Vector3 position = transform.position;
		position.y = position.y - (speed * Time.deltaTime);
		transform.position = position;
	}
}
