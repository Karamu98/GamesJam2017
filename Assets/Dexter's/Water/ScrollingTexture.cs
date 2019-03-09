using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{

    public float scrollSpeed = 0.9f;
    public float scrollSpeed2 = 0.9f; // the duration of each cycle of the animation
    Renderer Rend;
    Vector2 OffsetVector;
    // Use this for initialization
    void fixedupdate()
    {
        float offset = Time.time * scrollSpeed;
        float offset2 = Time.time * scrollSpeed2;
        OffsetVector.Set(offset2, offset);

        Rend.material.SetTextureOffset("Waves", OffsetVector);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
