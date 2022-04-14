using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ParticleSystem particle;
    bool collided = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            if (collided == false)
            {
                collided = true;
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                particle.Play();
                Destroy(this.gameObject, particle.main.duration);
            }
        }
    }
}
