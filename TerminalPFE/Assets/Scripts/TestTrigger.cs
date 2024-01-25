using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TestTrigger : MonoBehaviour, IDataManager
{
    public UnityEvent OnTrig;
    public int index;
    public GameObject playerAvatarSpawn;
    bool isOpen = false;

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
        if (other.tag == "Player")
        {
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
            other.GetComponent<PlayerInput>().DeactivateInput();
            OnTrig?.Invoke();
            transform.position = new Vector3(0, -5000, 0);
            sc_PlayerManager_HC.Instance.GetComponent<Animator>().Play("AnimInterractionNoReturn");
        }
    }

    public void BeamMeUp()
    {
        if (isOpen)
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
            sc_PlayerManager_HC.Instance.GetComponent<PlayerInput>().SwitchCurrentActionMap("Nothing");
            OnTrig?.Invoke();
            transform.position = new Vector3(0, -5000, 0);
            sc_PlayerManager_HC.Instance.GetComponent<Animator>().Play("AnimInterractionNoReturn");
        }
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
            transform.GetChild(i).GetComponent<MeshRenderer>().material = newMat;
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
