using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpgradeDetection : MonoBehaviour
{
    public int itemUpgrade; 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Points"))
        {
            itemUpgrade += 1;
        }
    }
}
