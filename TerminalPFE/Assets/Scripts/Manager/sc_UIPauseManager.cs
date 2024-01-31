using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class sc_UIPauseManager : MonoBehaviour
{
    public static sc_UIPauseManager Instance;

    public System.Action OnPause;

    public GameObject menuPause, inventaire, cameraGame, cameraPause, cameraInventaire;

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
        player = menuPause.transform.parent.parent;
        StartCoroutine(TestPauseAtStrat());
    }

    private void Update()
    {
        if (menuPause.activeInHierarchy || inventaire.activeInHierarchy)
        {
            if (Physics.Raycast(player.position + Vector3.up, player.forward, 2f))
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
            if (OnPause != null)
                OnPause();
            if (menuPause.activeInHierarchy) { EndPause(); }
            else { StartPause(); }
        }
    }

    void StartPause()
    {
        sc_PlayerManager_HC.Instance.SetInputMode("UI");
        //sc_SceneManager_HC.Instance.Pause();
        menuPause.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        cameraGame.SetActive(false);
        cameraPause.SetActive(true);
    }

    void EndPause()
    {
        menuPause.transform.GetChild(2).GetComponent<Animator>().SetBool("IsSelected", false);
        menuPause.transform.GetChild(3).GetComponent<Animator>().SetBool("IsSelected", false);
        menuPause.transform.GetChild(4).GetComponent<Animator>().SetBool("IsSelected", false);
        Camera.main.gameObject.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = 0.5f;
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
        sc_SceneManager_HC.Instance.Reprendre();
        menuPause.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        cameraGame.SetActive(true);
        cameraPause.SetActive(false);
    }


    public void Quitter()
    {
        sc_PlayerManager_HC.Instance.IndexTerminal = -1;
        sc_DataManager.instance.SaveAll();
        sc_SceneManager_HC.Instance.ChargeScene("MainMenu");
    }

    public void LoadInventory()
    {
        menuPause.transform.GetChild(2).GetComponent<Animator>().SetBool("IsSelected", false);
        menuPause.transform.GetChild(3).GetComponent<Animator>().SetBool("IsSelected", false);
        menuPause.transform.GetChild(4).GetComponent<Animator>().SetBool("IsSelected", false);
        Camera.main.gameObject.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = 0.15f;
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
            TestPause();
        }

    }
}
