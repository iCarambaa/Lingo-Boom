using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour {

	public List<Transform> cannonTips;
	public Transform cannon;
	public Transform cannonMount;
	public float cannonMovementSpeed = 0.1f;
	public GameObject target;
    public SpriteRenderer crosshair;

	private Transform lastUsedTip;

	public void Update(){
		updateRotation ();
	}

	public Transform getNextTip() {
		if (!lastUsedTip) {
			lastUsedTip = cannonTips [0];
			return lastUsedTip;
		}
		int next = (cannonTips.IndexOf (lastUsedTip) + 1) % cannonTips.Count;
		lastUsedTip = cannonTips [next];
		Debug.Log (next);
		return lastUsedTip;
	}

	private void updateRotation(){
		if (target) {
			Vector3 enemyPosition = target.transform.position;
			Vector3 stationPosition = cannonMount.position;

            crosshair.transform.position = enemyPosition;
			Vector3 direction = enemyPosition - stationPosition;
			Vector3 upVector = Vector3.up;

			//check if on the right, then rotate in the other direction
			float inverseDirection = 1.0f;
			if (direction.x > 0) {
				inverseDirection = -1.0f;
			}

			float angle = Vector3.Angle (upVector, direction);
			//the pivot point is set when importing the sprite
			Quaternion rotation = Quaternion.AngleAxis (angle * inverseDirection, new Vector3 (0, 0, 1));
			cannon.rotation = Quaternion.Lerp(cannon.rotation, rotation, cannonMovementSpeed * Time.deltaTime);
		}
	}
}
