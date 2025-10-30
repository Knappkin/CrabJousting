using NUnit.Framework;
using UnityEngine;

public class DrawTerrain : MonoBehaviour
{
    PerlinNoise terrain;
    LineRenderer lr;
    void Start()
    {
        terrain = GetComponent<PerlinNoise>();
        lr = GetComponent<LineRenderer>();
        lr.positionCount = terrain.colliderPoints.Count;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < terrain.colliderPoints.Count; i++)
        {
            lr.SetPosition (i, terrain.colliderPoints[i]);
        }
    }
}
