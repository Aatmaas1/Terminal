using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_LightAllumage : MonoBehaviour
{
    //public GameObject LightToOn;
    public GameObject[] LightsList;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i <= LightsList.Length ; i++)
            {
                LightsList[i].GetComponent<Animator>().SetTrigger("LightOn");
                Debug.Log(LightsList[0].name + " a allumé la lumière");


            }
            //Destroy(gameObject);
        }
        
        
    }
}
