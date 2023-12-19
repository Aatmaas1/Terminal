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
        if(value == 0)
        {
            sc_DataManager.instance.NewGame();
        }
        sc_SceneManager_HC.Instance.ChargeScene(sceneName);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        script.BoutonHover(value);
    }
}
