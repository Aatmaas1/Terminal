using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_LightAllumage : MonoBehaviour
{
    //public GameObject LightToOn;
    public GameObject[] LightsList;


    public void OnTriggerEnter(Collider other)
    {
        for(int i =0; i <= LightsList.Length; i++)
        {
            LightsList[0].GetComponent<Animator>().SetTrigger("LightOn");
            Destroy(gameObject);
        }
        
    }
}
