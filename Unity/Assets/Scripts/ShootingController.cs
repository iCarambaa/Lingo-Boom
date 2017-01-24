using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour {


	public Transform cannonTip;
	public Transform cannon;
	public Transform cannonMount;

	public GameObject target;

	public void Update(){
		updateRotation ();
	}

	private void updateRotation(){
		if (target) {
			Vector3 enemyPosition = target.transform.position;
			Vector3 stationPosition = cannonMount.position;

			Vector3 direction = enemyPosition - stationPosition;
			Vector3 upVector = Vector3.up;

			float angle = Vector3.Angle (upVector, direction);
			//the pivot point is set when importing the sprite
			Quaternion rotation = Quaternion.AngleAxis (angle, new Vector3 (0, 0, 1));
		}
	}
}
