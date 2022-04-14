using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
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
        objectW = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        objectH = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.x < minX + objectW) pos.x = minX+objectW;
        if (pos.x > maxX - objectW) pos.x = maxX-objectW;

        if (pos.y < minY + objectW) pos.y = minY +objectH;
        if (pos.y > maxY - objectW) pos.y = maxY - objectH;

        transform.position = pos;
    }
}
