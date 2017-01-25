using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnContact : MonoBehaviour
{

    public GameObject explosionPrefab;
	public string article;
    void OnMouseDown()
    {
        //Instantiate (explosionPrefab, transform.position, transform.rotation);
        //Destroy (gameObject);

        //TO DO: set this word as a target, so that the shooter knows where to shoot
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //projectile and enemy words match
        if (collision.gameObject.name.Equals(article))
        {
            //destroy object when projectile collides with it
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else //give a warning
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            Color color = renderer.material.color;
            Color blink = Color.red;
            //changing color
            StartCoroutine(Blink(renderer, color, blink));
        }

        //destroy projectile
        Destroy(collision.gameObject);
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