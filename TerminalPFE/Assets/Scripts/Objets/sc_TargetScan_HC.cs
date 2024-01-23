using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class sc_TargetScan_HC : MonoBehaviour, I_Interactible
{
    public UnityEvent EnterDetection;
    public UnityEvent ExitDetection;
    public UnityEvent Interract;

    public void GetClicked()
    {
        EnterDetection?.Invoke();
    }
    public void GetLost()
    {
        ExitDetection?.Invoke();
    }
    public void PressedInteract()
    {
        Interract?.Invoke();
    }
}
