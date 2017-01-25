using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<MeshRenderer>().sortingLayerName = "UI";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
