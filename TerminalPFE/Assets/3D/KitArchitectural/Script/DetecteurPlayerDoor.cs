using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecteurPlayerDoor : MonoBehaviour
{
    private UnityEventPortes UnityEventPortes;

    private void Start()
    {
        UnityEventPortes = GetComponentInParent<UnityEventPortes>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //print("La porte détecte le player en entrée" + transform.parent.name);
            UnityEventPortes.InteractDoorAutomatique();
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //print("La porte détecte le player en sortie" + transform.parent.name);
            UnityEventPortes.InteractDoorAutomatique();
        }
    }
    
}
