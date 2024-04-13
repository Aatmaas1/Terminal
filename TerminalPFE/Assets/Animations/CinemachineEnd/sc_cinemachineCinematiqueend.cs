using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_cinemachineCinematiqueend : MonoBehaviour
{
    
    public void GoToIddleAnimation()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("Iddle");
    }

    public void GoToEndAnimation()
    {
        this.gameObject.SetActive(true);
        
        this.gameObject.GetComponent<Animator>().SetTrigger("End");
    }
}
