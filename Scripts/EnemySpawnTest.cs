using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTest : MonoBehaviour
{
    float timer;
    public int level;


    public Enemy3 enemy;
    public GameObject spawn;
    public bool spawnActive = true;

    void Start()
    {
        timer = 20f;
    }


    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <0)
        {
            
            StopAllCoroutines();
            level++;
            timer = 20 + (5 * level);
            spawnActive = true;
            Debug.Log(level);
        }
        if(spawnActive)
        {
            for(int i = 0;i<3;i++)
            {
                StartCoroutine(Spawner());
            }
            
            spawnActive = false;
        }

    }

    IEnumerator Spawner()
    {

        
        while(timer >0)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            int locator = Random.Range(1, 5);
            if (locator == 1)
            {
                enemy.direction(locator);
                Instantiate(enemy, spawn.transform.position, Quaternion.identity);
            }
            if (locator == 2)
            {
                enemy.direction(locator);
                Instantiate(enemy, spawn.transform.position, Quaternion.identity);
            }
            if (locator == 3)
            {
                enemy.direction(locator);
                Instantiate(enemy, spawn.transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            }
            if (locator == 4)
            {
                enemy.direction(locator);
                Instantiate(enemy, spawn.transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            }
            else
            {
                yield return null;
            }

        }

        

    }
}
