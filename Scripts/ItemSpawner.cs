using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject health;
    public GameObject points;

    private float minX, maxX, minY, maxY, objectW, objectH;
  
    void Start()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y; 
        objectW = points.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectH = points.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        StartCoroutine(HealthSpawner());
        StartCoroutine(PointSpawner());
    }

    IEnumerator HealthSpawner()
    {
        yield return new WaitForSeconds(Random.Range(45,100));
        new WaitForSeconds(Random.Range(45,140));
        while(true)
        {
            Instantiate(health, new Vector2(Random.Range(minX+objectW, maxX - objectW), Random.Range(minY+objectH, maxY-objectH)), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(30,90));
        }
    }
    IEnumerator PointSpawner()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            Instantiate(points, new Vector2(Random.Range(minX+objectW, maxX - objectW), Random.Range(minY+objectH, maxY-objectH)), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3,8));
        }
    }  
}
