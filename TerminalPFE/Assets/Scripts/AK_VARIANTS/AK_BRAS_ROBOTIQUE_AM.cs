using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_BRAS_ROBOTIQUE_AM : MonoBehaviour
{
    public AK.Wwise.Event playEvent;

    public AK.Wwise.Event playWhenStopEvent;

    public AK.Wwise.Event stopEvent;

    public void PostEvent()
    {
        playEvent.Post(gameObject);
    }

    public void StopAndPlay()
    {
        stopEvent.Post(gameObject);
        playWhenStopEvent.Post(gameObject);
    }
}
