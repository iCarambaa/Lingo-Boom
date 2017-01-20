using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour {


	public Transform cannonTip;

	public void didTapEnemy(GameObject enemy){
		shootObject (enemy);
	}

	private void shootObject(GameObject enemy){
		Destroy (enemy);
	}
}
