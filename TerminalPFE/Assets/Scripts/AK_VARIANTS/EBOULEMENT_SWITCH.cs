using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class EBOULEMENT_SWITCH : MonoBehaviour
{
    public AK.Wwise.Event myEvent;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AudioListenerDontDestroyOnLoad.instance.AudioYuumi();
            AudioListenerDontDestroyOnLoad.instance.gameObject.transform.position = Vector3.zero;
            if(myEvent != null)
            {
                myEvent.Post(gameObject);
            }
        }
    }
}
