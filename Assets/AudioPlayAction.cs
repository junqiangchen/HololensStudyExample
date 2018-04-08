using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayAction : MonoBehaviour
{
    public AudioSource audio;

    public void clickfeedback()
    {
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }
}
