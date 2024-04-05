using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death4NN4 : MonoBehaviour
{
    public Animator PlayerAnimator;

    public GameObject fadeToBlack;

    [Header("Contrôle des timings")]
    public float timeToStop;
    public float timeToDie;
    public float timeToFade;
    public float timeToLoad;

    public AK_POSTEVENT_AM postEvent;

    private void Start()
    {
        postEvent = GetComponent<AK_POSTEVENT_AM>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WaitAnimDeath());
        }
    }


    IEnumerator WaitAnimDeath()
    {
        PlayerAnimator.GetComponent<Animator>().SetTrigger("SlowWalk");
        postEvent.PostEvent();

        yield return new WaitForSeconds(timeToStop);

        //PlayerAnimator.GetComponent<Animator>().SetTrigger("StopSlowWalk");

        //En attendant
        PlayerAnimator.GetComponent<Animator>().speed = 0.2f;
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");

        yield return new WaitForSeconds(timeToDie);

        PlayerAnimator.GetComponent<Animator>().speed = 1f;
        sc_ScreenShake.instance.ScreenBaseQuick();
        PlayerAnimator.GetComponent<Animator>().SetTrigger("Death");


        yield return new WaitForSeconds(timeToFade);

        fadeToBlack.SetActive(true);

        yield return new WaitForSeconds(timeToLoad);
        //sc_PlayerManager_HC.Instance.SetInputMode("Player");

        SceneManager.LoadScene("Introduction");

    }
}
