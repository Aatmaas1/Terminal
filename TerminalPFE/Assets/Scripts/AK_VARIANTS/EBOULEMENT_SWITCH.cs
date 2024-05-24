using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class EBOULEMENT_SWITCH : MonoBehaviour
{
    public AK_POSTEVENT_2_AM postEvent;

    public float waitHeartBeat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            postEvent.PostEvent1();
            AudioListenerDontDestroyOnLoad.instance.AudioYuumi();
            StartCoroutine(Post2AndDesactivate());
        }
    }

    public IEnumerator Post2AndDesactivate()
    {
        yield return new WaitForSeconds(waitHeartBeat);
        //AudioListenerDontDestroyOnLoad.instance.battementsCoeur.Post(AudioListenerDontDestroyOnLoad.instance.gameObject);
        AudioListenerDontDestroyOnLoad.instance.AfterEarthQuake();

        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
