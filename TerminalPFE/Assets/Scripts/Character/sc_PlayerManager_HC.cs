using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class sc_PlayerManager_HC : MonoBehaviour, IDataManager
{
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

    private void OnLevelWasLoaded(int level)
    {
        GetComponent<PlayerInput>().ActivateInput();
    }

    public void LoadData(GeneralData data)
    {
        if (IndexTerminal >= 0)
        {
            TestTrigger[] terminaux = FindObjectsOfType<TestTrigger>();
            for (int i = 0; i < terminaux.Length; i++)
            {
                if (terminaux[i].index == IndexTerminal)
                {
                    terminaux[i].SpawnPlayer();
                }
            }
        }
        else
        {
            if (data.LastPos != Vector3.zero)
            {
                transform.SetPositionAndRotation(data.LastPos, data.LastRot);
            }
        }
    }

    public void SaveData(ref GeneralData data)
    {
        data.LastPos = transform.position;
        data.LastRot = transform.rotation;
        data.indexterminal = IndexTerminal;
    }
}
