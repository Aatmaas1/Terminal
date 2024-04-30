using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class sc_MainMenuPlay : MonoBehaviour, IBoutonsMainMenu_HC, IPointerEnterHandler
{
    public int value;
    public sc_MainMenuManager_HC script;
    public string sceneName;
    public void IsClicked()
    {
        if(value == 1 || value == 3)
        {
            sc_DataManager.instance.NewGame();
        }
        if(sc_DataManager.instance.WhatIsLastScene() == 2)
        {
            sc_SceneManager_HC.Instance.ChargeScene("LevelDesignSimu");
        }
        else
        {
            sc_SceneManager_HC.Instance.ChargeScene(sceneName);
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(script != null)
        {
            script.BoutonHover(value);
        }
    }
}
