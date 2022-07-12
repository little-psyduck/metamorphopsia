using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectVertex : MonoBehaviour
{
    public Camera camera;

    Vector3 currentVertex;
    Ray ray;
    private void Start()
    {
        ray = new Ray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
        }
    }
}
