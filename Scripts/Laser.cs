using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float dirX = 0.1f;
    public float dirY = 0.1f;
    public bool horizontal;
    public Animator animator;
    public bool damage = false;
    public bool selfDestroy = false;
    void Start()
    {
        if (horizontal == false)
        {
            SpawnVertical();
        }
        else if(horizontal == true)
        {
            SpawnHorizontal();
        }
    }

    public void Update()
    {
        if(damage)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        if(selfDestroy)
        {
            Destroy(this.gameObject);
        }
    }
    public void SetDirection(float X,float Y, bool direct)
    {
        dirX = X;
        dirY = Y;
        horizontal = direct;
    }
    public void SpawnHorizontal()
    {
        transform.localPosition = new Vector2(transform.position.x, transform.position.y+dirY);
        transform.localScale = new Vector3(0.5f, 1, 1);
        transform.localRotation = Quaternion.Euler(0, 0, 90);
    }
    public void SpawnVertical()
    {
        transform.localPosition = new Vector2(transform.position.x + dirX, transform.position.y);
        transform.localScale = new Vector3(0.5f, 1, 1);
    }
}

