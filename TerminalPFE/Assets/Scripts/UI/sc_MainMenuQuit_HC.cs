using UnityEngine;

public class sc_MainMenuQuit_HC : MonoBehaviour, IBoutonsMainMenu_HC
{
    public int value;
    public sc_MainMenuManager_HC script;
    public void IsClicked()
    {
        sc_SceneManager_HC.Instance.Quitter();
    }

    private void OnMouseEnter()
    {
        Debug.Log("bbb");
        script.BoutonHover(value);
    }
}
