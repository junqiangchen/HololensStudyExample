using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZoomAction : MonoBehaviour, ISpeechHandler
{
    //this is zoom big function,when voice is bigger call PerformBigger
    public void PerformBigger()
    {
        Vector3 deltaScale = Vector3.zero;
        float scaleValue = 0.1f;
        deltaScale = transform.localScale * scaleValue;
        transform.localScale += deltaScale;
    }
    //this is zoom small ,when voice is smaller call PerformSmaller
    public void PerformSmaller()
    {
        Vector3 deltaScale = Vector3.zero;
        float scaleValue = -0.1f;
        deltaScale = transform.localScale * scaleValue;
        transform.localScale += deltaScale;
    }
    public void ChangeScale(string scale)
    {
        switch (scale.ToLower())
        {
            case "bigger":
                PerformBigger();
                break;
            case "smaller":
                PerformSmaller();
                break;
        }
    }
    public void OnSpeechKeywordRecognized(SpeechKeywordRecognizedEventData eventData)
    {
        ChangeScale(eventData.RecognizedText);
    }
}
