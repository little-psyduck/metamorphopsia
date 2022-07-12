using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomGrid;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
[ExecuteInEditMode]
public class GenerateGrid : MonoBehaviour
{
    MeshAdjuster adjuster = new MeshAdjuster();
    Mesh mesh;

    private void OnEnable()
    {
        mesh = new Mesh { name = "Generated Grid" };

        if (adjuster.Initilize(ref mesh))
        {
            this.GetComponent<MeshFilter>().mesh = mesh;
        }

        else
        {
            Debug.Log("Mesh initialization fault.");
        }
    }

    private void Awake()
    {
        OnEnable();
    }

    private void Update()
    {
    }
}
