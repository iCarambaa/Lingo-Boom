using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBridge : MonoBehaviour {

	public ShootingController shootingController;

	public void animationDidEnd(){
		shootingController.didRecharge ();
	}
}
