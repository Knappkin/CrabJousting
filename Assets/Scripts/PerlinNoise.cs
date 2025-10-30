using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class PerlinNoise : MonoBehaviour
{
    public float heightScale = 1.0f;
    public float xScale = 1.0f;

    public List<Vector2> colliderPoints;
    public PolygonCollider2D Points;

    private Vector2 start;
    private Vector2 end;

    //private CanvasRenderer levelMeshCanvasRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomNum = Random.Range(0f, 10f);
        xScale = randomNum;
        int randomNum2 = Random.Range(1, 3);
        heightScale = randomNum2;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2[] perlinToCollision = Points.points;
        for (int pn = 2; pn < colliderPoints.Count - 2; pn++)
        {
            float height = heightScale * Mathf.PerlinNoise1D(colliderPoints[pn].x * xScale);
            Vector2 newPoint = colliderPoints[pn];
            newPoint.y = height;
            colliderPoints[pn] = newPoint;
            perlinToCollision[pn] = newPoint;


            //Vector3 pos = transform.position;
            //pos.y = height;
            //transform.position = pos;


        }
        Points.points = perlinToCollision;

        //for (int l = 0; l < colliderPoints.Count; l++)
        //{
        //    Mesh mesh = new Mesh();

        //    Vector3[] vertices = new Vector3[19];
        //    Vector2[] uv = new Vector2[19];
        //    int[] triangles = new int[19];

        //    vertices[0] = Vector3.zero;
        //    vertices[1] = new Vector3();
        //}



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