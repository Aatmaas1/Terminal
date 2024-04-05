using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt4NN4 : MonoBehaviour
{
    public Animator PlayerAnimator;
    public GameObject rope4NN4ToPlanner;

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
        rope4NN4ToPlanner.SetActive(false);


        yield return new WaitForSeconds(7f);
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
        rope4NN4ToPlanner.SetActive(true);
    }
}
