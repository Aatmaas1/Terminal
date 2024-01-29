using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Linq;

public class sc_PlayerManager_HC : MonoBehaviour, IDataManager
{
    public ParticleSystem OnJumping;

    public static sc_PlayerManager_HC Instance;
    public int IndexTerminal = -1;

    PlayerInput pInput;

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

    private void Start()
    {
        GetComponent<PlayerInput>().ActivateInput();
        pInput = GetComponent<PlayerInput>();
    }

    public void LoadData(GeneralData data)
    {
        IndexTerminal = data.indexterminal;
        //Debug.Log(data.LastPos);
        if (IndexTerminal >= 0)
        {
            TestTrigger[] terminaux = FindObjectsOfType<TestTrigger>();
            for (int i = 0; i < terminaux.Length; i++)
            {
                if (terminaux[i].index == IndexTerminal)
                {
                    GetComponent<CharacterController>().enabled = false;
                    transform.position = terminaux[i].playerAvatarSpawn.transform.position;
                    transform.rotation = terminaux[i].playerAvatarSpawn.transform.rotation;
                }
            }
        }
        else
        {
            if (data.LastPos != Vector3.zero)
            {
                GetComponent<CharacterController>().enabled = false;
                transform.position = data.LastPos;
                transform.rotation = data.LastRot;
            }
        }
        GetComponent<CharacterController>().enabled = true;
    }

    public void SaveData(ref GeneralData data)
    {
        data.LastPos = transform.position;
        data.LastRot = transform.rotation;
        data.indexterminal = IndexTerminal;
        if(SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            data.lastSceneLoaded = SceneManager.GetActiveScene().buildIndex;
        }
    }

    public void OnClick()
    {
        IEnumerable<I_Interactible> datapersistenceobjects = FindObjectsOfType<MonoBehaviour>().OfType<I_Interactible>();
        foreach (I_Interactible interf in datapersistenceobjects)
        {
            interf.PressedInteract();
        }
    }

    public void OnJump()
    {
        OnJumping.GetComponent<ParticleSystem>().Play();
        sc_ScreenShake.instance.FovBase();
        //Debug.Log("Appeler de base");
    }

    /// <summary>
    /// A choisir entre Player, UI et Nothing
    /// </summary>
    /// <param name="mode"></param>
    public void SetInputMode(string mode)
    {
        pInput.SwitchCurrentActionMap(mode);
    }

    public void SetCamTo(Transform obj)
    {
        StartCoroutine(TurnCam(obj));
    }

    IEnumerator TurnCam(Transform obj)
    {
        Quaternion oldrot = transform.GetChild(0).rotation;
        for (int i = 1; i<= 20; i++)
        {
            Debug.Log("aaaaa");
            transform.GetChild(0).rotation = Quaternion.RotateTowards(transform.GetChild(0).rotation,
                Quaternion.LookRotation(obj.position - transform.GetChild(0).position, Vector3.up),9f);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 1; i <= 60; i++)
        {
            Debug.Log("aaaaa");
            transform.GetChild(0).rotation = Quaternion.RotateTowards(transform.GetChild(0).rotation, oldrot, 3f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
