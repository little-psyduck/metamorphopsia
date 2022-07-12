using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraView : MonoBehaviour
{
    public float sceneWidth = 19.2f;
    
    private void Awake()
    {
        float unitsPerPixel = sceneWidth / (float)Screen.width;
        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;
        gameObject.GetComponent<Camera>().orthographicSize = desiredHalfHeight;
    }
}
