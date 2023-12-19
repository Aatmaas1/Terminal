using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class sc_UIPauseManager : MonoBehaviour
{
    public static sc_UIPauseManager Instance;

    public GameObject menuPause;
    public PlayerInput pInput;
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

    public void TestPause()
    {
        if (menuPause.activeInHierarchy) { EndPause(); }
        else { StartPause();}
    }

    void StartPause()
    {
        pInput.SwitchCurrentActionMap("UI");
        sc_SceneManager_HC.Instance.Pause();
        menuPause.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    void EndPause()
    {
        pInput.SwitchCurrentActionMap("Player");
        sc_SceneManager_HC.Instance.Reprendre();
        menuPause.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void Quitter()
    {
        sc_SceneManager_HC.Instance.ChargeScene("MainMenu");
    }
}
