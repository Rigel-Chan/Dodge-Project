using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    public float Hdir = 1f;
    public float Vdir = 1f;

    public int itemUpgrade = 0;

    void Update()
    {      
        rb.velocity = new Vector2(Hdir * speed, Vdir * speed);     
    }
    public void direction(int spawnPoint)
    {
        if (spawnPoint == 1)
        {
            Hdir = 0.7f;
            Vdir = -0.7f;
        }
        if (spawnPoint == 2)
        {
            Hdir = -0.7f;
            Vdir = -0.7f;
        }
        if (spawnPoint == 3)
        {
            Hdir = -0.7f;
            Vdir = 0.7f;
        }
        if (spawnPoint == 4)
        {
            Hdir = 0.7f;
            Vdir = 0.7f;
        }
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject,2);
    }
}
