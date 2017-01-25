using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

	public float scrollingSpeed = 1.0f;
	public float scrollBorder = 13.0f;
	
	// Update is called once per frame
	void Update () {
		Vector3 cPosition = transform.position;
		cPosition.y -= scrollingSpeed * Time.deltaTime;
		cPosition.y = cPosition.y % scrollBorder;
		transform.position = cPosition;

	}
}
