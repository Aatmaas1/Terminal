using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class sc_TutoManager_HC : MonoBehaviour
{
    public static sc_TutoManager_HC Instance;

    public GameObject CamGameplay, CamTuto, Trigger1, Trigger2, TriggerPorte1;

    public float StartDelay;

    Animator Anims;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        Anims = GetComponent<Animator>();


        if(sc_DataManager.instance.TestIsNewSave())
        {
            TriggerPorte1.SetActive(false);
            StartCoroutine(DelayStart());
        }
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(StartDelay);
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        CamGameplay.SetActive(false);
        Anims.Play("TutoMove1");

    }

    public void TriggerActivated(int index)
    {
        if(index == 1)
        {
            StartCoroutine(DelayTutoMove2());
        }


        if(index == 2)
        {
            TriggerPorte1.SetActive(true); ;
        }
    }

    IEnumerator DelayTutoMove2()
    {
        yield return new WaitForSeconds(0.1f);
        Anims.Play("TutoMove2");

    }

    public void StopAnim()
    {
        CamGameplay.SetActive(true);
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
        CamGameplay.GetComponent<CinemachineVirtualCamera>().LookAt = null;
    }
}
