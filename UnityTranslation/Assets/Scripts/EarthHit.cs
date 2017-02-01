using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthHit : MonoBehaviour {

    
    public GameObject playerLife;
    public int lives;
    public Sprite emptyLife;
    
	public GameController gameController;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TO DO: decrease player life
        SpriteRenderer[] live = playerLife.transform.GetComponentsInChildren<SpriteRenderer>();

        if(lives > 1)
        {
            lives--;
            live[lives % 3].sprite = emptyLife;
            
        } else
        {
			gameController.gameOver ();
        }

        //TO DO: stop tracking target that has damaged player

        //damage
        Renderer renderer = gameObject.GetComponent<Renderer>();
        Color color = renderer.material.color;
        Color blink = Color.red;
        //changing color
        StartCoroutine(Blink(renderer, color, blink));
    }

    IEnumerator Blink(Renderer renderer, Color color, Color blinkColor)
    {

        float blink = 0.1f;

        for (int i = 0; i < 3; i++)
        {

            renderer.material.SetColor("_Color", blinkColor);
            yield return new WaitForSeconds(blink);

            renderer.material.SetColor("_Color", color);
            yield return new WaitForSeconds(blink);

        }

        renderer.material.SetColor("_Color", color);
    }

}
