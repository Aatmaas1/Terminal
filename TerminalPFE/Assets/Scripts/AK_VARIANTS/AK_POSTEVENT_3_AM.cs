using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_POSTEVENT_3_AM : MonoBehaviour
{
    public AK.Wwise.Event stopEvent;

    public AK.Wwise.Event playEvent;

    public void PostAndStopEvents()
    {
        stopEvent.Post(gameObject);
        playEvent.Post(gameObject);
    }
}
