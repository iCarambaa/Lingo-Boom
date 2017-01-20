using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public ShootingController shootingController;
	void OnMouseDown() {
		shootingController.didTapEnemy (gameObject);
	}
}
