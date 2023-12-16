using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventPortes : MonoBehaviour
{

    public UnityEvent OnInteractDoorAutomatique;

    public UnityEvent OnInteractDoorBouton;

    public void InteractDoorAutomatique()
    {
        OnInteractDoorAutomatique?.Invoke();
    }


    public void InteractDoorBouton()
    {
        OnInteractDoorBouton?.Invoke();
    }
}
