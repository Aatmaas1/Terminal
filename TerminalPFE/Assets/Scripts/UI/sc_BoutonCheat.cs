using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_BoutonCheat : MonoBehaviour
{
    public void JeCheat()
    {
        sc_DataManager.instance.CheatCode();
        sc_SceneManager_HC.Instance.ChargeScene("LevelDesignReel");
        Cursor.lockState = CursorLockMode.Locked;
    }
}
