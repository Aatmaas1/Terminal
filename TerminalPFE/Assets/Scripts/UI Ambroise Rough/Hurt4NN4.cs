using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Hurt4NN4 : MonoBehaviour
{
    public Animator PlayerAnimator;
    public GameObject rope4NN4ToPlanner;
    public CinemachineVirtualCamera vCam;

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
        vCam.Priority = 30;
        yield return new WaitForSeconds(1f);
        vCam.Priority = 8;

        yield return new WaitForSeconds(6f);
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
        rope4NN4ToPlanner.SetActive(true);
    }
}
