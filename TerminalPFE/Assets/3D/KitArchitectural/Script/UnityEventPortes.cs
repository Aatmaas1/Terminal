using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventPortes : MonoBehaviour
{

    public bool isDoorBroken;

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

    private void Start()
    {
        if(isDoorBroken)
        {
            GetComponent<Animator>().SetBool("IsBroken", true);
        }
    }
}
