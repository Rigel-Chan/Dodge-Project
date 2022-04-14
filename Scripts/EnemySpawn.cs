using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Enemy enemy;
    public Enemy2 enemy2;
    public Enemy3 enemy3;
    public Laser laser;
    public GameObject[] spawn;
    public float enemy1SpawnMax = 5f;
    public float enemy2SpawnMax = 5f;
    public float laserSpawnMax = 10f;

    public bool spawnActive = true;
    public int level;
    public float speed = 0f;
    public float speedIncrease = 0.4f;
    public int enemy2LvlSpawn = 3;
    public int laserLvlSpawn = 5;
    int spawnIndicator = 0;
    float timer;


    float itemIncrease;
    public float increaseIncrement;
    void Start()
    {
        level = 1;
        itemIncrease = 0f;
        speed = 0f;
        spawnActive = true;
        enemy.speed = 10f;
        enemy2.speed = 10f;
        timer = 10f;
        spawnIndicator = 0;
        StartCoroutine(Spawner());
    }
    public void FixedUpdate()
    {
        timer -= Time.deltaTime;
    }
    void Update()
    {
        GameObject[] enemycount = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemycount.Length; i++)
        {
            if (enemycount[i].GetComponent<EnemyUpgradeDetection>().itemUpgrade > 0)
            {
                enemycount[i].GetComponent<EnemyUpgradeDetection>().itemUpgrade = 0;
                itemIncrease += increaseIncrement;               
            }
            else return;
        }
        timer -= Time.deltaTime;
        if (timer < 0)
        {

            StopAllCoroutines();
            level++;
            speed += (speedIncrease*itemIncrease);
            if(enemy1SpawnMax>1f)
            {
                enemy1SpawnMax -= 0.3f + (0.5f * itemIncrease);
            }
            if (enemy2SpawnMax > 1f && level == enemy2LvlSpawn)
            {
                enemy2SpawnMax -= 0.3f + (0.5f * itemIncrease);
            }
            if (laserSpawnMax > 3f && level == laserLvlSpawn)
            {
                laserSpawnMax -= 0.3f + (0.5f * itemIncrease);
            }
            itemIncrease = 0;
            timer = 10 + (5 * level);
            spawnActive = true;

        }
        if (spawnActive)
        {

            int checker = level % 2;
            if(checker == 0)
            {
                spawnIndicator++;
            }
            for(int i = 0; i<(1+spawnIndicator);i++)
            {
                StartCoroutine(Spawner());
                
            }
            if (level >= laserLvlSpawn)
            {
                for (int i = 0; i < (1+(spawnIndicator/3)); i++)
                {
                    StartCoroutine(LaserSpawn());
                }
            }
            StartCoroutine(Spawner3());
            Debug.Log(spawnIndicator);
            spawnActive = false;
        }
    }
    IEnumerator Spawner()
    {
        enemy.speed += speed;
        if (level >= enemy2LvlSpawn)
        {
            StartCoroutine(Spawner2());
        }
        while (timer>0)
        {
            yield return new WaitForSeconds(Random.Range(1f, enemy1SpawnMax));
            int locator = Random.Range(1, 5);
            if (locator == 1)
            {
                enemy.direction(locator);
                Instantiate(enemy, new Vector2(spawn[0].transform.position.x, Random.Range(-10, 10)), Quaternion.identity);
            }
            if (locator == 2)
            {
                enemy.direction(locator);
                Instantiate(enemy, new Vector2(spawn[1].transform.position.x, Random.Range(-10, 10)), Quaternion.identity);
            }
            if (locator == 3)
            {
                enemy.direction(locator);
                Instantiate(enemy, new Vector2(Random.Range(-18, 18), spawn[2].transform.position.y), Quaternion.identity);
            }
            if (locator == 4)
            {
                enemy.direction(locator);
                Instantiate(enemy, new Vector2(Random.Range(-18, 18), spawn[3].transform.position.y), Quaternion.identity);
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator Spawner2()
    {
        enemy2.speed += (speed / 2.5f);
        while (timer>0)
        {
            yield return new WaitForSeconds(Random.Range(1f, enemy2SpawnMax));
            int locator = Random.Range(1, 5);
            if (locator == 1)
            {
                enemy2.direction(locator);
                Instantiate(enemy2, new Vector2(spawn[4].transform.position.x, spawn[4].transform.position.y + Random.Range(-17, 17)), Quaternion.Euler(new Vector3(0, 0, -135)));

            }
            if (locator == 2)
            {
                enemy2.direction(locator);
                Instantiate(enemy2, new Vector2(spawn[5].transform.position.x, spawn[5].transform.position.y + Random.Range(-17, 17)), Quaternion.Euler(new Vector3(0, 0, 135)));

            }
            if (locator == 3)
            {
                enemy2.direction(locator);
                Instantiate(enemy2, new Vector2(spawn[6].transform.position.x + Random.Range(-17, 17), spawn[6].transform.position.y), Quaternion.Euler(new Vector3(0, 0, 45)));

            }
            if (locator == 4)
            {
                enemy2.direction(locator);
                Instantiate(enemy2, new Vector2(spawn[7].transform.position.x + Random.Range(-17, 17), spawn[7].transform.position.y), Quaternion.Euler(new Vector3(0, 0, -45)));
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator Spawner3()
    {
        enemy3.speed = 5f; 
        while (timer > 0)
        {
            yield return new WaitForSeconds(10);
            int locator = Random.Range(1, 5);
            if (locator == 1)
            {
                enemy3.direction(locator);
                Instantiate(enemy3, new Vector2(spawn[0].transform.position.x, Random.Range(-5, 5)), Quaternion.identity);

            }
            if (locator == 2)
            {
                enemy3.direction(locator);
                Instantiate(enemy3, new Vector2(spawn[1].transform.position.x, Random.Range(-5, 5)), Quaternion.identity);

            }
            if (locator == 3)
            {
                enemy3.direction(locator);
                Instantiate(enemy3, new Vector2(Random.Range(-10, 10), spawn[2].transform.position.y), Quaternion.Euler(new Vector3(0, 0, 90)));

            }
            if (locator == 4)
            {
                enemy3.direction(locator);
                Instantiate(enemy3, new Vector2(Random.Range(-10, 10), spawn[3].transform.position.y), Quaternion.Euler(new Vector3(0, 0, 90)));
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator LaserSpawn()
    {
        while (timer>0)
        {
            yield return new WaitForSeconds(Random.Range(3f, laserSpawnMax));

            int locator = Random.Range(1, 5);
            if (locator == 1)
            {
                laser.SetDirection(-0.1f, 0, true);
                Instantiate(laser, new Vector2(0, Random.Range(-10, 10)), Quaternion.identity);
            }
            if (locator == 2)
            {
                laser.SetDirection(0.1f, 0, true);
                Instantiate(laser, new Vector2(0, Random.Range(-10, 10)), Quaternion.identity);
            }
            if (locator == 3)
            {
                laser.SetDirection(0, 0.1f, false);
                Instantiate(laser, new Vector2(Random.Range(-15, 15), 0), Quaternion.identity);
            }
            if (locator == 4)
            {

                laser.SetDirection(0, -0.1f, false);
                Instantiate(laser, new Vector2(Random.Range(-15, 15), 0), Quaternion.identity);
            }
            else
            {
                yield return null;
            }
        }
    }
}


