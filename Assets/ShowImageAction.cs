using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImageAction : MonoBehaviour
{
    private RawImage image;
    // Use this for initialization
    void Start ()
    {
        image = GetComponent<RawImage>();
    }

    public void ShowImage()
    {
        var textureimage = (Texture2D)Resources.Load("img1");
        image.texture = textureimage;
    }
}
