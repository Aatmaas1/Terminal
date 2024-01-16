using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class sc_UIPauseManager : MonoBehaviour
{
    public static sc_UIPauseManager Instance;

    public GameObject menuPause, inventaire, cameraGame, cameraPause, cameraInventaire;
    public PlayerInput pInput;

    Transform player;
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

    private void Start()
    {
        player = menuPause.transform.parent;
        StartCoroutine(TestPauseAtStrat());
    }

    private void Update()
    {
        if (menuPause.activeInHierarchy)
        {
            if (Physics.Raycast(player.position + Vector3.up, player.forward + Vector3.up, 2.5f))
            {
                player.GetComponent<CharacterController>().enabled = false;
                player.Rotate(new Vector3(0, 10, 0));
                player.GetComponent<CharacterController>().enabled = true;
            }
        }
    }

    public void TestPause()
    {
        if (!inventaire.activeInHierarchy)
        {
            if (menuPause.activeInHierarchy) { EndPause(); }
            else { StartPause(); }
        }
    }

    void StartPause()
    {
        pInput.SwitchCurrentActionMap("UI");
        //sc_SceneManager_HC.Instance.Pause();
        menuPause.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        cameraGame.SetActive(false);
        cameraPause.SetActive(true);
    }

    void EndPause()
    {
        pInput.SwitchCurrentActionMap("Player");
        sc_SceneManager_HC.Instance.Reprendre();
        menuPause.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        cameraGame.SetActive(true);
        cameraPause.SetActive(false);
    }


    public void Quitter()
    {
        sc_DataManager.instance.SaveAll();
        sc_SceneManager_HC.Instance.ChargeScene("MainMenu");
    }

    public void LoadInventory()
    {
        inventaire.SetActive(true);
        cameraInventaire.SetActive(true);
        menuPause.SetActive(false);
        cameraPause.SetActive(false);
    }
    public void CloseInventory()
    {
        inventaire.SetActive(false);
        cameraInventaire.SetActive(false);
        menuPause.SetActive(true);
        cameraPause.SetActive(true);
    }

    IEnumerator TestPauseAtStrat()
    {
        yield return new WaitForSeconds(0.1f);
        if (sc_DataManager.instance.WhatIsLastScene() == 3)
        {
            StartPause();
        }

    }
}
