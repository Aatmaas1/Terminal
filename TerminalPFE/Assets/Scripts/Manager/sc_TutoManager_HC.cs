using Cinemachine;
using System.Collections;
using UnityEngine;

public class sc_TutoManager_HC : MonoBehaviour
{
    public static sc_TutoManager_HC Instance;

    public GameObject CamGameplay, CamTuto, Trigger1, Trigger2, TriggerPorte1, TriggerTutoMoveStart;

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


        if (sc_DataManager.instance.TestIsNewSave())
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
        switch (index)
        {
            case 1:
                StartCoroutine(DelayTutoMove2());
                break;


            case 2:
                TriggerPorte1.SetActive(true);
                Anims.Play("TutoMoveEnd");
                TriggerTutoMoveStart.SetActive(true);
                break;

            case 3:
                Anims.Play("TutoInteract");
                break;
        }
    }


    IEnumerator DelayTutoMove2()
    {
        yield return new WaitForSeconds(0.1f);
        Anims.Play("TutoMove2");
        Trigger2.SetActive(true);

    }

    public void StopAnim()
    {
        CamGameplay.SetActive(true);
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
        CamGameplay.GetComponent<CinemachineVirtualCamera>().LookAt = null;
    }

    public void BoutonPressed()
    {
        Anims.Play("TutoEnd");
    }
}
