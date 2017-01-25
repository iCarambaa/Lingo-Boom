using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    //where the projectile comes from
    public GameObject cannonTip;
    public GameObject projectile;
    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //modify later - to button press
    private void OnMouseDown()
    {
        //instantiate projectile
        GameObject tempProjectile;
        tempProjectile = Instantiate(projectile, cannonTip.transform.position, cannonTip.transform.rotation) as GameObject;
        //assign a tab to the projectile - a word that we want to match with enemy
        tempProjectile.name = this.GetComponentInChildren<TextMesh>().text;

        //target position
        Vector2 position = target.transform.position - cannonTip.transform.position;

        //control the rigidbody component of projectile to shoot it
        Rigidbody2D tempRigidbody;
        tempRigidbody = tempProjectile.GetComponent<Rigidbody2D>();

        //shoot the projectile
        tempRigidbody.velocity = position * 10;


        //after 2 second projectile is automatically destroyed if not used
        Destroy(tempProjectile, 2.0f);
    }
}
