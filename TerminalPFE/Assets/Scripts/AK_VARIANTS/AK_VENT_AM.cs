using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_VENT_AM : MonoBehaviour
{
    public AK.Wwise.Event vent;

    private void OnEnable()
    {
        vent.Post(gameObject);
    }
}
