using System;
using UnityEngine;

public class sc_Test : MonoBehaviour
{
    public static sc_Test instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public Action OnTamer;
    public void Tamer()
    {

    }
}
