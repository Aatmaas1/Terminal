using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_TRIGGERPOST_2_AM : MonoBehaviour
{
    public AK_POSTEVENT_2_AM postEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            postEvent.PostEvent1();
            postEvent.PostEvent2();
        }
    }
}
