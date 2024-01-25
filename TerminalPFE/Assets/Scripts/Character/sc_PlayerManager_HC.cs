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
        //Debug.Log("Appeler de base");
    }
}
