using Cinemachine;
using System.Collections;
using UnityEngine;

public class sc_TutoManager_HC : MonoBehaviour, IDataManager
{
    public static sc_TutoManager_HC Instance;

    public GameObject CamGameplay, CamTuto, Trigger1, Trigger2, TriggerPorte1, TriggerTutoMoveStart;

    public float StartDelay;

    Animator Anims;
    bool Porte0Ouverte = true;


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
            Porte0Ouverte = false;
            StartCoroutine(DelayStart());
        }
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(StartDelay);
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        CamGameplay.SetActive(false);
        Anims.Play("TutoMove1");
        Trigger1.SetActive(true);
    }

    public void TriggerActivated(int index)
    {
        switch (index)
        {
            case 1:
                StartCoroutine(DelayTutoMove2());
                TriggerPorte1.SetActive(true);
                break;


            case 2:
                //TriggerPorte1.SetActive(true);
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
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        yield return new WaitForSeconds(0.1f);
        OuvrePorte();
        sc_PlayerManager_HC.Instance.SetCamTo(transform.GetChild(4));
        Anims.Play("TutoMove2");

        yield return new WaitForSeconds(3f);
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
        //Trigger2.SetActive(true);

    }

    public void StopAnim()
    {
        CamGameplay.SetActive(true);
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
        CamGameplay.GetComponent<CinemachineVirtualCamera>().LookAt = null;
    }

    public void Boutoned()
    {
        if (Porte0Ouverte)
        {
            Anims.Play("TutoEnd");
        }
    }

    public void OuvrePorte()
    {
        Porte0Ouverte = true;
        TriggerPorte1.GetComponentInParent<UnityEventPortes>().InteractDoorBouton();
    }

    public void LoadData(GeneralData data)
    {
        if (data.porteTuto0Ouverte)
        {
            Porte0Ouverte = true;
            StartCoroutine(Starting());
        }
    }

    public void SaveData(ref GeneralData data)
    {
        data.porteTuto0Ouverte = Porte0Ouverte;
    }

    IEnumerator Starting()
    {
        yield return new WaitForSeconds(0.1f);
        OuvrePorte();
    }
}
