using UnityEngine;
using UnityEngine.EventSystems;

public class sc_MainMenuQuit_HC : MonoBehaviour, IBoutonsMainMenu_HC, IPointerEnterHandler
{
    public int value;
    public sc_MainMenuManager_HC script;
    public void IsClicked()
    {
        sc_SceneManager_HC.Instance.Quitter();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        script.BoutonHover(value);
    }
}
