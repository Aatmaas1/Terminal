using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class sc_TargetScan_HC : MonoBehaviour
{
    public UnityEvent GetDetected;
    public UnityEvent GetUndetected;
    public UnityEvent Interract;

    public void GetClicked()
    {
        GetDetected?.Invoke();
    }
    public void GetLost()
    {
        GetUndetected?.Invoke();
    }
    public void GetUsed()
    {
        Interract?.Invoke();
    }
}
