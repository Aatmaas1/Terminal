using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_plateformeSimu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
     /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("La plateforme détecte le player en entrée");

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("La plateforme détecte le player en sortie");

        }
    }
     */

   // /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<MeshRenderer>().material.color = new Color(0f, 1f, 1f, 1f);
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            //Debug.Log("La plateforme détecte le player en entrée");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<MeshRenderer>().material.color = Color.red;

            //Debug.Log("La plateforme détecte le player en sortie");
        }
    }
   // */
}
