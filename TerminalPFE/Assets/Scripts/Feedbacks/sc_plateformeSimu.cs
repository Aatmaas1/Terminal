using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_plateformeSimu : MonoBehaviour
{
    public int idBox;

    bool on = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<MeshRenderer>().material.color = new Color(0f, 1f, 1f, 1f);
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            on = true;
            //Debug.Log("La plateforme détecte le player en entrée");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<MeshRenderer>().material.color = new Color(0.2784313725490196f, 0.00784313725490196f, 0.30980392156862746f);

            //Debug.Log("La plateforme détecte le player en sortie");
        }
    }
}
