using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt4NN4 : MonoBehaviour
{
    public Animator PlayerAnimator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          
            StartCoroutine(WaitAnimHurt());


        }
    }


    IEnumerator WaitAnimHurt()
    {
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        sc_ScreenShake.instance.ScreenBaseQuick();
        PlayerAnimator.GetComponent<Animator>().SetTrigger("Hurting");


        yield return new WaitForSeconds(4f);
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
        
    }
}
