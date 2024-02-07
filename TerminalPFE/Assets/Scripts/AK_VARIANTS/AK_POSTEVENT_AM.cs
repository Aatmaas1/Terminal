using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_POSTEVENT_AM : MonoBehaviour
{
    public AK.Wwise.Event playScan;

    public void PostEvent()
    {
        playScan.Post(gameObject);
    }
}
