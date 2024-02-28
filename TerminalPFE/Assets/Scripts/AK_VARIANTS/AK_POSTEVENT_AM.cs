using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_POSTEVENT_AM : MonoBehaviour
{
    public AK.Wwise.Event playEvent;

    public AK.Wwise.Event stopEvent;

    public void PostEvent()
    {
        playEvent.Post(gameObject);
    }

    public void PostStopEvent()
    {
        stopEvent.Post(gameObject);
    }
}
