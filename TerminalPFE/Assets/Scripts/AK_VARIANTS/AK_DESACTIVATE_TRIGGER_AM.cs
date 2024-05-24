using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class AK_DESACTIVATE_TRIGGER_AM : MonoBehaviour
{

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(Desactivate());
        }     
    }

    public IEnumerator Desactivate()
    {
        yield return new WaitForSeconds(0.5f);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
