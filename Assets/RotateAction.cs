using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateAction : MonoBehaviour, INavigationHandler
{
    //rotate parameter
    public float RotationSensitivity = 10.0f;
    private float rotationFactor;
    public void OnNavigationCanceled(NavigationEventData eventData)
    {
        //do nothing
    }
    public void OnNavigationCompleted(NavigationEventData eventData)
    {
        //do nothing
    }
    public void OnNavigationStarted(NavigationEventData eventData)
    {
        //do nothing;
    }
    public void OnNavigationUpdated(NavigationEventData eventData)
    {
        rotationFactor = eventData.CumulativeDelta.x * RotationSensitivity;
        transform.Rotate(new Vector3(0, -1 * rotationFactor, 0));
    }
}
