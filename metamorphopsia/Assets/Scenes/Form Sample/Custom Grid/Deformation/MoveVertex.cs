using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertex : MonoBehaviour
{
    public Camera camera;

    int selectedVertexIndex = -1;
    Vector3[] vertices;
    Vector3 mouseObjectPosiion;

    void GetSelectedVertex()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < vertices.Length; ++i)
            {
                float distance = (mouseObjectPosiion - vertices[i]).sqrMagnitude;
                if (distance < 0.1)
                {
                    selectedVertexIndex = i;
                    break;
                }
            }
            Debug.Log(selectedVertexIndex);
        }
    }

    void MoveSelectedVertex()
    {
        if (Input.GetMouseButton(0) && selectedVertexIndex != -1)
        {
            vertices[selectedVertexIndex] = mouseObjectPosiion;
            GetComponent<MeshFilter>().mesh.SetVertices(vertices);
        }
    }
    
    void CancelSelect()
    {
        if (Input.GetMouseButtonUp(0))
        {
            selectedVertexIndex = -1;
        }
    }

    void Update()
    {
        vertices = GetComponent<MeshFilter>().mesh.vertices;
        mouseObjectPosiion = transform.worldToLocalMatrix * camera.ScreenToWorldPoint(Input.mousePosition);
        mouseObjectPosiion.z = 0f;

        GetSelectedVertex();
        MoveSelectedVertex();
        CancelSelect();
    }
}
