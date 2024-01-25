using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : MonoBehaviour, IDataManager
{
    private UnityEventPortes UnityEventPortes;
    public GameObject PorteOuvertureParBouton;

    public int index;
    bool isOpen = false;
    bool PlayerClose = false;

    private void Start()
    {
        UnityEventPortes = PorteOuvertureParBouton.GetComponent<UnityEventPortes>();
    }

    /*public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = true;
            //print("La porte détecte le player en entrée" + transform.parent.name);
            UnityEventPortes.InteractDoorBouton();

            this.gameObject.SetActive(false);

            sc_ScreenShake.instance.ScreenBaseQuick();
        }
    }*/

    public void AppuyeBouton()
    {
        if (PlayerClose && isOpen == false)
        {
            isOpen = true;
            //print("La porte détecte le player en entrée" + transform.parent.name);
            UnityEventPortes.InteractDoorBouton();
            this.gameObject.GetComponent<Animator>().SetTrigger("IsClick");
            //this.gameObject.SetActive(false);

            //sc_ScreenShake.instance.ScreenBaseQuick();
            sc_ScreenShake.instance.OnInteractPlayerLight();
            sc_PlayerManager_HC.Instance.GetComponent<Animator>().Play("AnimInterraction");
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
        }
    }

    IEnumerator Ouvre()
    {
        yield return new WaitForSeconds(0.1f);
        UnityEventPortes.InteractDoorBouton();
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
