using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using AK.Wwise;

public class Hurt4NN4 : MonoBehaviour
{
    public Animator PlayerAnimator;
    public GameObject rope4NN4ToPlanner;
    public CinemachineVirtualCamera vCam;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(LPF());

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

    public float timeBeforeLPFRemoval;
    public float timeToNoLPF;
    public float startingLPFValue;
    public float targetLPFValue;

    public AK.Wwise.Event battementCoeur;

    public IEnumerator LPF()
    {
        AkSoundEngine.SetRTPCValue("BatterieFaible", startingLPFValue);

        battementCoeur.Post(gameObject);

        yield return new WaitForSeconds(timeBeforeLPFRemoval);

        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime / timeToNoLPF;
            AkSoundEngine.SetRTPCValue("BatterieFaible", Mathf.Lerp(startingLPFValue, targetLPFValue, time));
            yield return null;
            StopCoroutine(LPF());
        }
    }
}
