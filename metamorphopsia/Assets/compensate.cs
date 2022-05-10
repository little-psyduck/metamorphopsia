using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compensate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer original_pic = this.gameObject.GetComponent<SpriteRenderer>();
        Texture2D post_pic = new Texture2D(799, 798);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
