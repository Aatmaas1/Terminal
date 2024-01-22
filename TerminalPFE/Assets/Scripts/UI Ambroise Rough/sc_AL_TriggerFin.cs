using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_AL_TriggerFin : MonoBehaviour
{
    public GameObject PanelFinRough;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PanelFinRough.SetActive(true);
        }
    }
}
