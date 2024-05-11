using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_POSTEVENT_2_AM : MonoBehaviour
{
    public AK.Wwise.Event playEvent;

    public AK.Wwise.Event playEvent2;

    public void Post2Event()
    {
        playEvent.Post(gameObject);
        playEvent2.Post(gameObject);
    }

    public void PostEvent1()
    {
        playEvent.Post(gameObject);
    }

    public void PostEvent2()
    {
        playEvent2.Post(gameObject);
    }
}
