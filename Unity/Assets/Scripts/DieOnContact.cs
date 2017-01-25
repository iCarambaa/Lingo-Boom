using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnContact : MonoBehaviour {


	public GameObject explosionPrefab;


	void OnMouseDown(){
		Instantiate (explosionPrefab, transform.position, transform.rotation);
		Destroy (gameObject);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destroy object when projectile collides with it
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}