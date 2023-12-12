using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_InGameMemory_HC : MonoBehaviour
{
    public static sc_InGameMemory_HC Instance;
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
        DontDestroyOnLoad(this);
    }


    private void OnLevelWasLoaded(int level)
    {
        if(IndexTerminal >= 0)
        {
            TestTrigger[] terminaux = FindObjectsOfType<TestTrigger>();
            for (int i =0; i< terminaux.Length; i++)
            {
                if(terminaux[i].index == IndexTerminal)
                {
                    terminaux[i].SpawnPlayer();
                }
            }
        }
    }
}
