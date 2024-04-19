using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_TriggerSetActiveTrue : MonoBehaviour
{
    public GameObject Objet¿FaireApparaitre;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Objet¿FaireApparaitre.SetActive(true);
        }
    }
}
