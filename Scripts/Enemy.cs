using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    public int Hdir;
    public int Vdir;

    void Update()   
    {
        transform.Rotate(0, 0, 0.5f, Space.Self);
        rb.velocity = new Vector2(Hdir*speed,Vdir*speed);
    }
    public void direction(int spawnPoint)
    {
        if(spawnPoint == 1)
        {
            Hdir = -1;
            Vdir = 0;
        }
        if (spawnPoint == 2)
        {
            Hdir = 1;
            Vdir = 0;
        }
        if (spawnPoint == 3)
        {
            Hdir = 0;
            Vdir = 1; 
        }
        if(spawnPoint == 4)
        {
            Hdir = 0;
            Vdir = -1; 
        }
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject,5);
    }
}
