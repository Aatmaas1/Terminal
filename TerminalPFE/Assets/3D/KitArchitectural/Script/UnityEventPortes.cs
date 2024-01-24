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
       // sc_ScreenShake.instance.ScreenBaseQuick();

    }


    public void InteractDoorBouton()
    {
        OnInteractDoorBouton?.Invoke();
       // sc_ScreenShake.instance.ScreenBaseQuick();

    }

    private void Start()
    {
        if(isDoorBroken)
        {
            GetComponent<Animator>().SetBool("IsBroken", true);
        }
    }
}
