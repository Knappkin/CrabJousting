using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Linq;

public class PerlinNoise : MonoBehaviour
{
    public float heightScale = 1.0f;
    public float xScale = 1.0f;

    public List<Vector2> colliderPoints;

    private Vector2 start;
    private Vector2 end;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int pn = 2; pn < colliderPoints.Count - 2; pn++)
        {
            float height = heightScale * Mathf.PerlinNoise1D(colliderPoints[pn].x * xScale);
            Vector2 newPoint = colliderPoints[pn];
            newPoint.y = height;
            colliderPoints[pn] = newPoint;

            //Vector3 pos = transform.position;
            //pos.y = height;
            //transform.position = pos;
        }

        //if (pn == colliderPoints[16].x)
        //{
        DrawLevel(colliderPoints);
        //}
    }

    public void DrawLevel(List<Vector2> colliderPoints)
    {
        for (int i = 0; i < colliderPoints.Count - 1; i++)
        {
            start = colliderPoints[i];
            end = colliderPoints[i + 1];

            Debug.DrawLine(start, end, Color.white);
        }
    }
}
