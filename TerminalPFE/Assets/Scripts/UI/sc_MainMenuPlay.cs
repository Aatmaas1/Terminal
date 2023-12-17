using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_MainMenuPlay : MonoBehaviour, IBoutonsMainMenu_HC
{
    public int value;
    public sc_MainMenuManager_HC script;
    public string sceneName;
    public void IsClicked()
    {
        sc_SceneManager_HC.Instance.ChargeScene(sceneName);
    }

    private void OnMouseOver()
    {
        //Debug.Log("aaa");
        script.BoutonHover(value);
    }
}
