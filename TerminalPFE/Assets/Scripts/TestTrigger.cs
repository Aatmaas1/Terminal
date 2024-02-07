using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;
using System.Collections;

public class TestTrigger : MonoBehaviour, IDataManager
{
    public UnityEvent OnTrig;
    public int index;
    public GameObject playerAvatarSpawn;
    bool isOpen = false;
    VisualEffect Vfx;
    float color = 0;
    public float ChangementVitesseTerminalAnimation;
    bool isInUse = false;
    private void Start()
    {
        Vfx = GetComponent<VisualEffect>();
    }
    private void FixedUpdate()
    {
        if (Vfx != null && SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (isOpen && color < 1)
            {
                color += 0.05f;
            }
            if (!isOpen && color > 0)
            {
                color -= 0.05f;
            }
            Vfx.SetFloat("ColorChanger", color);
        }
    }

    public bool isUse = false;
    public Material nonUseMat;
    public Material useMat;
    private void Update()
    {
        if (isUse == true)
        {
            ChangingColor(useMat);
        }
        else
        {
            ChangingColor(nonUseMat);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isInUse)
        {
            isInUse = true;
            if (index == 1 && SceneManager.GetActiveScene().buildIndex == 2)
            {
                sc_DataManager.instance.MoveRobotTuto(false);
                //Debug.Log("DeclencheSortie");
            }
            if (index == 2 && SceneManager.GetActiveScene().buildIndex == 2)
            {
                sc_DataManager.instance.MoveRobotTuto(true);
                //Debug.Log("DeclencheSortie");
            }
            if (index == 3)
            {
                sc_DataManager.instance.MoveRobotCorpse();
                //Debug.Log("DeclencheSortie");
            }

            sc_PlayerManager_HC.Instance.IndexTerminal = index;
            sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
            sc_PlayerManager_HC.Instance.GetComponent<Animator>().Play("AnimEntreeTerminalSimu");
            GetComponent<sc_animationTerminalSimu>().lePersoSortDeSimu();
            StartCoroutine(DelayEffet());
        }
    }

    public void BeamMeUp()
    {
        if (isOpen && !isUse)
        {
            isUse = true;
            if (index == 1 && SceneManager.GetActiveScene().buildIndex == 2)
            {
                sc_DataManager.instance.MoveRobotTuto(false);
            }
            if (index == 2 && SceneManager.GetActiveScene().buildIndex == 2)
            {
                sc_DataManager.instance.MoveRobotTuto(true);
            }
            if (index == 3)
            {
                sc_DataManager.instance.MoveRobotCorpse();
            }

            sc_PlayerManager_HC.Instance.IndexTerminal = index;
            sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
            sc_PlayerManager_HC.Instance.LookA(transform.GetChild(2));
            sc_PlayerManager_HC.Instance.MoveToTerminal(transform);
            sc_PlayerManager_HC.Instance.GetComponent<Animator>().Play("AnimEntreeTerminalReel");
            sc_UIPauseManager.Instance.cameraPause.SetActive(false);
            StartCoroutine(DelayEffet());
        }
    }

    IEnumerator DelayEffet()
    {
        yield return new WaitForSeconds(ChangementVitesseTerminalAnimation);
        OnTrig?.Invoke();
    }

    public void PlayerReady()
    {
        isOpen = true;
    }

    public void LostPlayer()
    {
        isOpen = false;
    }

    public void ChangingColor(Material newMat)
    {
        int enfants = transform.childCount;
        for (int i = 0; i < enfants; i++)
        {
            if (transform.GetChild(i).GetComponent<MeshRenderer>())
            {
                transform.GetChild(i).GetComponent<MeshRenderer>().material = newMat;
            }
        }
    }

    public void LoadData(GeneralData data)
    {
        switch (index)
        {
            case 1: //Si on est le terminal en bas du tuto
                if (!data.tutoBody) //Si on a pas pris (corps en haut)
                { isUse = false; }
                else { isUse = true; }
                break;
            case 2: //Si on est le terminal en haut du tuto
                if (!data.tutoBody) //Si on a pas pris (corps en haut)
                { isUse = true; }
                else { isUse = false; }
                break;

            case 3: //Si on est le terminal en bas du refectoire
                if (!data.hasSwitchedBody) //Si on a pas pris (corps en haut)
                { isUse = false; }
                else { isUse = true; }
                break;
            case 4: //Si on est le terminal en haut du refectoire
                if (!data.hasSwitchedBody) //Si on a pas pris (corps en haut)
                { isUse = true; }
                else { isUse = false; }
                break;
        }
    }

    public void SaveData(ref GeneralData data)
    {
        //   throw new System.NotImplementedException();
    }
}
