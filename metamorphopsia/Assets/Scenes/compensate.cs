using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compensate : MonoBehaviour
{
    public Vector2 centre;
    [Range(0, 500.0f)]
    public float radius;
    public Material mat;
    [Range(0, 2.0f)]
    public float extent;
    // Start is called before the first frame update
    void Start()
    {
        centre.x = 0.52f;centre.y = 0.5f;
        radius = 0.22f;
        extent = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetVector("centre", centre);
        mat.SetFloat("radius", radius);
        mat.SetFloat("extent", extent);
    }
}
