using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorShowAction : MonoBehaviour, IFocusable
{
    private Color currentcolor;
    public void OnFocusEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    public void OnFocusExit()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = currentcolor;
    }
    // Use this for initialization
    void Start()
    {
        currentcolor = gameObject.GetComponent<MeshRenderer>().material.color;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
