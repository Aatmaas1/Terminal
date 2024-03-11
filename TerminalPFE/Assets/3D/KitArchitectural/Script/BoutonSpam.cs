using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

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
            if(compteur >= nbFakeAppuyage)
            {
                isOpen = true;
                UnityEventPortes.InteractDoorBouton();
                this.gameObject.GetComponent<Animator>().SetTrigger("IsClick");
                sc_ScreenShake.instance.OnInteractPlayerLight();
                StartCoroutine(CamPorte());
            }
            else
            {
                compteur += 1;
                StopAllCoroutines();
                StartCoroutine(CDSpam());
                StartCoroutine(FakeCamPorte());
                this.gameObject.GetComponent<Animator>().SetTrigger("FakeClick");
            }

            this.gameObject.GetComponentInChildren<ParticleSystem>().Play();
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
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        sc_PlayerManager_HC.Instance.TurnPlayerToward(transform);
        yield return new WaitForSeconds(0.5f);
        sc_PlayerManager_HC.Instance.MakeCamLookAt(PorteOuvertureParBouton.transform.GetChild(3));

        yield return new WaitForSeconds(3f);
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
    }
    IEnumerator FakeCamPorte()
    {
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        sc_PlayerManager_HC.Instance.TurnPlayerToward(transform);
        yield return new WaitForSeconds(1.2f);
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
}
