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

    private void Start()
    {
        Tamer();
    }


    public System.Action OnTamer;
    public void Tamer()
    {
        print("Tamer");
    }
}
