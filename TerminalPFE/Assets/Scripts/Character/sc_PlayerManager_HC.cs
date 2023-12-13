using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_PlayerManager_HC : MonoBehaviour
{
    public static sc_PlayerManager_HC Instance;
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
}
