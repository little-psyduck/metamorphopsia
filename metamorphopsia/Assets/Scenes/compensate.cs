using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compensate : MonoBehaviour
{
    public Vector2 centre;
    [Range(0, 500.0f)]
    public float radius;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer original_pic = this.gameObject.GetComponent<SpriteRenderer>();
        Texture2D post_pic = new Texture2D(799, 798);
        for (int i = 0; i < post_pic.height; ++i)
        {
            for (int j = 0; j < post_pic.width; ++j)
            {
                post_pic.SetPixel(j, i, Color.blue);
            }
        }
        post_pic.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetVector("centre", centre);
        mat.SetFloat("radius", radius);
    }
}
