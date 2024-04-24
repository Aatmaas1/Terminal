using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class Bouton : MonoBehaviour, IDataManager
{
    private UnityEventPortes UnityEventPortes;
    public GameObject PorteOuvertureParBouton;

    public int index;
    bool isOpen = false;
    bool PlayerClose = false;
    VisualEffect Vfx;
    public VisualEffect VfxFeedBack;
    float color = 0;
    public int cardID = 0;

    public GameObject holoText;
    public sc_Digicode_HC checkDigi;

    private void Start()
    {
        UnityEventPortes = PorteOuvertureParBouton.GetComponent<UnityEventPortes>();
        Vfx = GetComponentInChildren<VisualEffect>();
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
            if (cardID != 0)
            {
                if (!sc_DataManager.instance.CheckID(cardID))
                {
                    StartCoroutine(Blocked());
                    return;
                }
            }
            if (checkDigi != null)
            {
                checkDigi.Open();
                return;
            }
            isOpen = true;
            //print("La porte détecte le player en entrée" + transform.parent.name);
            UnityEventPortes.InteractDoorBouton();
            this.gameObject.GetComponent<Animator>().SetTrigger("IsClick");
            VfxFeedBack.SendEvent("OnBouton");
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
                isOpen = data.porteDirecteur;
                if (isOpen)
                {
                    StartCoroutine(Ouvre());
                }
                break;
            case 4:
                isOpen = data.porteProd;
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
                data.porteDirecteur = isOpen;
                break;
            case 4:
                data.porteProd = isOpen;
                break;
        }
    }

    IEnumerator Ouvre()
    {
        yield return new WaitForSeconds(0.1f);
        Material m = transform.GetChild(3).GetComponent<MeshRenderer>().materials[1];
        m.SetColor("_Color", new Color(22f, 191f, 0));
        m.SetColor("_EmissionColor", new Color(22f, 191f, 0) / 100f);
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

    IEnumerator Blocked()
    {
        Material bleu = new Material(transform.GetChild(3).GetComponent<MeshRenderer>().materials[1]);
        Material m = transform.GetChild(3).GetComponent<MeshRenderer>().materials[1];
        yield return new WaitForSeconds(0.1f);
        m.SetColor("_Color", new Color(190f, 0f, 0));
        m.SetColor("_EmissionColor", new Color(190f, 0f, 0) / 100f);
        if (holoText != null)
        {
            holoText.GetComponent<TMPro.TMP_Text>().text = "ERROR";
        }
        yield return new WaitForSeconds(0.8f);
        transform.GetChild(3).GetComponent<MeshRenderer>().materials[1] = bleu;
        m.SetColor("_Color", bleu.GetColor("_Color"));
        m.SetColor("_EmissionColor", bleu.GetColor("_EmissionColor"));
        if (holoText != null)
        {
            holoText.GetComponent<TMPro.TMP_Text>().text = "Access \n card needed";
        }
    }

    public void AppelDigicode()
    {
        isOpen = true;
        //print("La porte détecte le player en entrée" + transform.parent.name);
        UnityEventPortes.InteractDoorBouton();
        this.gameObject.GetComponent<Animator>().SetTrigger("IsClick");
        VfxFeedBack.SendEvent("OnBouton");
        //this.gameObject.SetActive(false);

        //sc_ScreenShake.instance.ScreenBaseQuick();
        sc_ScreenShake.instance.OnInteractPlayerLight();
        sc_PlayerManager_HC.Instance.GetComponent<Animator>().Play("AnimInterraction");
        StartCoroutine(CamPorte());
    }
}
