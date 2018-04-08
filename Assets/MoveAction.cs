using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveAction : MonoBehaviour, IManipulationHandler
{
    //move parameter
    public float MoveSensitivity = 1.5f;
    private Vector3 originPosition;
    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        //do nothing
    }
    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        //do nothing
    }
    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        originPosition = transform.position;
    }
    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        Vector3 cumulative = new Vector3(eventData.CumulativeDelta.x, eventData.CumulativeDelta.y, eventData.CumulativeDelta.z);
        transform.position = originPosition + cumulative * MoveSensitivity;
    }
}
