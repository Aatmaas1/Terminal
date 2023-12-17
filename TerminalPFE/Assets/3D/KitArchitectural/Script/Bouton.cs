using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : MonoBehaviour
{
    private UnityEventPortes UnityEventPortes;
    public GameObject PorteOuvertureParBouton;
    private void Start()
    {
        UnityEventPortes = PorteOuvertureParBouton.GetComponent<UnityEventPortes>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //print("La porte d�tecte le player en entr�e" + transform.parent.name);
            UnityEventPortes.InteractDoorBouton();
        }
    }
}
