using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line
{
    private float scale = 0.01f;
    private Vector3[] points;

    private GameObject lineObject;
    private Mesh lineMesh;

    private Material lineMaterial;

    public Line(Vector3[] points_, Material lineMaterial_ = null)
    {
        this.lineMaterial = lineMaterial_;
        if (lineMaterial == null)
            lineMaterial = new Material(Shader.Find("Standard"));

        this.points = points_;
        lineMesh = new Mesh();
        GenerateLine();
        GenerateLineTriangle();

        lineObject.AddComponent<MeshFilter>().mesh = lineMesh;
        lineObject.AddComponent<MeshRenderer>();
    }

    void GenerateLine()
    {
        Vector3[] vectors = new Vector3[points.Length-1];
        Vector3[] normals = new Vector3[points.Length];

        for (int i = 0; i < points.Length - 1; ++i)
        {
            vectors[i] = points[i + 1] - points[i];
            
            if (i == 0)
                normals[i] = new Vector3(-vectors[i].y, vectors[i].x, 0f).normalized;

            else
            {
                normals[i] = ((new Vector3(-vectors[i].y, vectors[i].x, 0f).normalized + normals[i - 1])).normalized;
            }
        }

        normals[normals.Length - 1] = 
        new Vector3(-vectors[vectors.Length-1].y, vectors[vectors.Length - 1].x, 0f).normalized;

        CalculatePointsPosition(normals);
    }

    void CalculatePointsPosition(Vector3[] normals)
    {
        Vector3[] generatedPoints = new Vector3[points.Length * 2];
        int index = 0;

        for (int i = 0; i < points.Length; i++)
        {
            generatedPoints[index++] = points[i] - (normals[i] * scale);
            generatedPoints[index++] = points[i] + (normals[i] * scale);
        }

        lineMesh.SetVertices(generatedPoints);
    }

    void GenerateLineTriangle()
    {
        int[] triangles = new int[(points.Length - 1) * 6];

        int index = 0;
        for (int i = 0; i < points.Length - 1; i++)
        {
            triangles[index++] = i * 2;
            triangles[index++] = i * 2 + 1;
            triangles[index++] = i * 2 + 2;
        }
        for (int i = 0; i < points.Length - 1; i++)
        {
            triangles[index++] = i * 2 + 1;
            triangles[index++] = i * 2 + 3;
            triangles[index++] = i * 2 + 2;
        }

        lineMesh.triangles = triangles;
    }
}
