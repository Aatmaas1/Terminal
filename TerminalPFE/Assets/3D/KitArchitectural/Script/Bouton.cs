using System.Collections;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

public class Bouton : MonoBehaviour, IDataManager
{
    private UnityEventPortes UnityEventPortes;
    public GameObject PorteOuvertureParBouton;

    private AK_POSTEVENT_2_AM access;


    public int index;
    bool isOpen = false;
    bool PlayerClose = false;
    VisualEffect Vfx;
    public VisualEffect VfxFeedBack;
    float color = 0;
    public int cardID = 0;

    public GameObject holoText;
    public sc_Digicode_HC checkDigi;
    public GameObject logo;
    public Sprite logoCard, logoCross;
    bool _isBlocked = false;
    [Tooltip("Donner en référence tout bouton de l'autre coté de la porte")]
    public Bouton jumeau;

    public string textError;
    private void Start()
    {
        UnityEventPortes = PorteOuvertureParBouton.GetComponent<UnityEventPortes>();
        access = GetComponent<AK_POSTEVENT_2_AM>();
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
        if (PlayerClose && isOpen == false && !_isBlocked)
        {
            sc_PlayerManager_HC.Instance.GetComponent<Animator>().Play("AnimInterraction");
            sc_ScreenShake.instance.OnInteractPlayerLight();
            sc_PlayerManager_HC.Instance.TurnPlayerToward(transform);
            sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
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
            //this.gameObject.SetActive(false);

            //sc_ScreenShake.instance.ScreenBaseQuick();
            StartCoroutine(CamPorte());

            if(jumeau != null)
            {
                jumeau.PasseVert();
            }
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
        PorteOuvertureParBouton.GetComponent<Animator>().speed = 1000;
        yield return new WaitForEndOfFrame();
        UnityEventPortes.InteractDoorBouton();
    }
    IEnumerator CamPorte()
    {
        yield return new WaitForSeconds(0.5f);
        //sc_PlayerManager_HC.Instance.MakeCamLookAt(PorteOuvertureParBouton.transform.GetChild(4));
        PorteOuvertureParBouton.transform.GetChild(5).gameObject.SetActive(true);

        UnityEventPortes.InteractDoorBouton();
        this.gameObject.GetComponent<Animator>().SetTrigger("IsClick");
        VfxFeedBack.SendEvent("OnBouton");

        yield return new WaitForSeconds(0.2f);
        PasseVert();
        if (holoText != null)
        {
            holoText.GetComponent<TMPro.TMP_Text>().text = "";
        }

        yield return new WaitForSeconds(1.5f);
        PorteOuvertureParBouton.transform.GetChild(5).gameObject.SetActive(false);
        yield return new WaitForSeconds(1.3f);
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
        _isBlocked = true;
        Material bleu = new Material(transform.GetChild(3).GetComponent<MeshRenderer>().materials[1]);
        Material m = transform.GetChild(3).GetComponent<MeshRenderer>().materials[1];

        yield return new WaitForSeconds(0.5f);
        access.PostEvent2();
        m.SetColor("_Color", new Color(190f, 0f, 0));
        m.SetColor("_EmissionColor", new Color(190f, 0f, 0) / 100f);
        if (holoText != null)
        {
            holoText.GetComponent<TMPro.TMP_Text>().text = "ERROR";
        }
        logo.GetComponent<Image>().sprite = logoCross;

        yield return new WaitForSeconds(0.5f);
        sc_PlayerManager_HC.Instance.SetInputMode("Player");

        yield return new WaitForSeconds(0.3f);
        transform.GetChild(3).GetComponent<MeshRenderer>().materials[1] = bleu;
        m.SetColor("_Color", bleu.GetColor("_Color"));
        m.SetColor("_EmissionColor", bleu.GetColor("_EmissionColor"));
        if (holoText != null)
        {
            holoText.GetComponent<TMPro.TMP_Text>().text = textError;
        }
        logo.GetComponent<Image>().sprite = logoCard;
        _isBlocked = false;
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

    public void PasseVert()
    {
        access.PostEvent1();
        isOpen = true;
        Material m = transform.GetChild(3).GetComponent<MeshRenderer>().materials[1];
        m.SetColor("_Color", new Color(22f, 191f, 0));
        m.SetColor("_EmissionColor", new Color(22f, 191f, 0) / 100f);
        Destroy(logo);
    }
}
