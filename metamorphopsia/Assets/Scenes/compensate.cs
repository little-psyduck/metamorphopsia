using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compensate : MonoBehaviour
{
    public Vector2 centre_gather;
    public Vector2 centre_shape;
    [Range(0, 500.0f)]
    public float radius;
    public Material mat;
    [Range(0, 2.0f)]
    public float extent;
    // Start is called before the first frame update
    void Start()
    {
        centre_shape.x = 0.52f; centre_shape.y = 0.5f;
        centre_gather.x = 0.48f; centre_gather.y = 0.5f;
        radius = 0.22f;
        extent = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetVector("centre_shape", centre_shape);
        mat.SetVector("centre_gather", centre_gather);

        mat.SetFloat("radius", radius);
        mat.SetFloat("extent", extent);
    }
}
