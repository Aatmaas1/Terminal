using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_TRIGGERPOST_AM : MonoBehaviour
{
    public AK_POSTEVENT_AM postEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            postEvent.PostEvent();
        }
    }
}
