using System.Collections;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;
using static ak.wwise.core;

public class BoutonSpam : MonoBehaviour, IDataManager
{
    private UnityEventPortes UnityEventPortes;
    public GameObject PorteOuvertureParBouton;


    bool isOpen = false;
    bool PlayerClose = false;
    VisualEffect Vfx;
    float color = 0;
    public int nbFakeAppuyage = 2;
    public float delayReset = 1;
    int compteur = 0;

    public GameObject holoText;
    public sc_Digicode_HC checkDigi;
    public GameObject logo;
    public Sprite logoCard, logoCross;
    bool _isBlocked = false;

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

    public void AppuyeBouton()
    {
        if (PlayerClose && isOpen == false && !_isBlocked)
        {
            if(compteur >= nbFakeAppuyage)
            {
                sc_PlayerManager_HC.Instance.GetComponent<Animator>().Play("AnimInterraction");
                sc_ScreenShake.instance.OnInteractPlayerLight();
                sc_PlayerManager_HC.Instance.TurnPlayerToward(transform);
                sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
                isOpen = true;
                StartCoroutine(CamPorte());
            }
            else
            {
                compteur += 1;
                StopAllCoroutines();
                StartCoroutine(CDSpam());
                StartCoroutine(Blocked());
                this.gameObject.GetComponent<Animator>().SetTrigger("FakeClick");
            }

            //this.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            sc_PlayerManager_HC.Instance.GetComponent<Animator>().Play("AnimInterraction");
        }
    }


    public void LoadData(GeneralData data)
    {
        isOpen = data.porteSpam;
        if (isOpen)
        {
            StartCoroutine(Ouvre());
        }
    }

    public void SaveData(ref GeneralData data)
    {
        data.porteSpam = isOpen;
    }

    IEnumerator Ouvre()
    {
        yield return new WaitForSeconds(0.1f);
        UnityEventPortes.InteractDoorBouton();
    }
    IEnumerator CamPorte()
    {
        yield return new WaitForSeconds(0.5f);
        PorteOuvertureParBouton.transform.GetChild(4).gameObject.SetActive(true);

        UnityEventPortes.InteractDoorBouton();
        this.gameObject.GetComponent<Animator>().SetTrigger("IsClick");

        yield return new WaitForSeconds(0.2f);
        PasseVert();
        if (holoText != null)
        {
            holoText.GetComponent<TMPro.TMP_Text>().text = "";
        }

        yield return new WaitForSeconds(1.5f);
        PorteOuvertureParBouton.transform.GetChild(4).gameObject.SetActive(false);
        yield return new WaitForSeconds(1.3f);
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
    }

    IEnumerator CDSpam()
    {
        yield return new WaitForSeconds(delayReset);
        compteur = 0;
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
            holoText.GetComponent<TMPro.TMP_Text>().text = "Please \n try again";
        }
        logo.GetComponent<Image>().sprite = logoCard;
        _isBlocked = false;
    }

    public void PasseVert()
    {
        Material m = transform.GetChild(3).GetComponent<MeshRenderer>().materials[1];
        m.SetColor("_Color", new Color(22f, 191f, 0));
        m.SetColor("_EmissionColor", new Color(22f, 191f, 0) / 100f);
        Destroy(logo);
    }
}
