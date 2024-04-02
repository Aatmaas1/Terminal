using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Cinemachine;

public class Bouton : MonoBehaviour, IDataManager
{
    private UnityEventPortes UnityEventPortes;
    public GameObject PorteOuvertureParBouton;
    public bool CardTuto = false;
    public bool CardEnd = false;

    public int index;
    bool isOpen = false;
    bool PlayerClose = false;
    VisualEffect Vfx;
    float color = 0;

    private void Start()
    {
        UnityEventPortes = PorteOuvertureParBouton.GetComponent<UnityEventPortes>();
        Vfx = GetComponent<VisualEffect>();
    }
    private void FixedUpdate()
    {
        if (PlayerClose && color < 1)
        {
            color += 0.05f;
        }
        if (!PlayerClose && color > 0)
        {
            color -= 0.05f;
        }
        Vfx.SetFloat("ColorChanger", color);
    }

    /*public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = true;
            //print("La porte d�tecte le player en entr�e" + transform.parent.name);
            UnityEventPortes.InteractDoorBouton();

            this.gameObject.SetActive(false);

            sc_ScreenShake.instance.ScreenBaseQuick();
        }
    }*/

    public void AppuyeBouton()
    {
        if (PlayerClose && isOpen == false)
        {
            if (CardTuto && !sc_DataManager.instance.TestCard(1))
            {
                Debug.Log("manque carte");
                return;
            }
            if (CardEnd && !sc_DataManager.instance.TestCard(2))
            {
                return;
            }
            if (CardTuto && CardEnd && !sc_DataManager.instance.TestCard(3))
            {
                return;
            }
            Debug.Log("oui carte");

            isOpen = true;
            //print("La porte d�tecte le player en entr�e" + transform.parent.name);
            UnityEventPortes.InteractDoorBouton();
            this.gameObject.GetComponent<Animator>().SetTrigger("IsClick");
            this.gameObject.GetComponentInChildren<VisualEffect>().SendEvent("OnBOuton");
            //this.gameObject.SetActive(false);

            //sc_ScreenShake.instance.ScreenBaseQuick();
            sc_ScreenShake.instance.OnInteractPlayerLight();
            sc_PlayerManager_HC.Instance.GetComponent<Animator>().Play("AnimInterraction");
            StartCoroutine(CamPorte());
        }
    }

    
    public void LoadData(GeneralData data)
    {
        switch (index)
        {
            case 0:
                isOpen = data.porteTuto1Ouverte;
                if (isOpen)
                {
                    StartCoroutine(Ouvre());
                }
                break;
            case 1:
                isOpen = data.porteTuto2Ouverte;
                if (isOpen)
                {
                    StartCoroutine(Ouvre());
                }
                break;
            case 2:
                isOpen = data.porteSortieOuverte;
                if (isOpen)
                {
                    StartCoroutine(Ouvre());
                }
                break;
            case 3:
                isOpen = data.doc1;
                if (isOpen)
                {
                    StartCoroutine(Ouvre());
                }
                break;
        }
    }

    public void SaveData(ref GeneralData data)
    {
        switch (index)
        {
            case 0:
                data.porteTuto1Ouverte = isOpen;
                break;
            case 1:
                data.porteTuto2Ouverte = isOpen;
                break;
            case 2:
                data.porteSortieOuverte = isOpen;
                break;
            case 3:
                data.doc1 = isOpen;
                break;
        }
    }

    IEnumerator Ouvre()
    {
        yield return new WaitForSeconds(0.1f);
        UnityEventPortes.InteractDoorBouton();
    }
    IEnumerator CamPorte()
    {
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        sc_PlayerManager_HC.Instance.TurnPlayerToward(transform);
        yield return new WaitForSeconds(0.5f);
        sc_PlayerManager_HC.Instance.MakeCamLookAt(PorteOuvertureParBouton.transform.GetChild(4));

        yield return new WaitForSeconds(3f);
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
    }

    public void PlayerReady()
    {
        PlayerClose = true;
    }

    public void LostPlayer()
    {
        PlayerClose = false;
    }
}
