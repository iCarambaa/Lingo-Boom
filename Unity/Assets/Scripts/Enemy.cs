using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10.0f;
	public ShootingController shootingController;
	void OnMouseDown() {
		shootingController.target = gameObject;
	}

	void Update() {
		Vector3 position = transform.position;
		position.y = position.y - (speed * Time.deltaTime);
		transform.position = position;
	}
}
