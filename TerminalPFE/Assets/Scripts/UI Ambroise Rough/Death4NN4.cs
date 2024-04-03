using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death4NN4 : MonoBehaviour
{
    public Animator PlayerAnimator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WaitAnimDeath());
        }
    }


    IEnumerator WaitAnimDeath()
    {
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        sc_ScreenShake.instance.ScreenBaseQuick();
        PlayerAnimator.GetComponent<Animator>().SetTrigger("Death");


        yield return new WaitForSeconds(3f);
        //sc_PlayerManager_HC.Instance.SetInputMode("Player");
        SceneManager.LoadScene("Introduction");

    }
}
