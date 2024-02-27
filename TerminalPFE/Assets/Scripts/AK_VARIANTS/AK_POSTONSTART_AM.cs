using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_POSTONSTART_AM : MonoBehaviour
{
    public AK_POSTEVENT_AM postEvent;

    public void Start()
    {
        postEvent = GetComponent<AK_POSTEVENT_AM>();
        postEvent.PostEvent();
    }
}
