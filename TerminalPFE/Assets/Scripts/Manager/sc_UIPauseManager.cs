using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sc_UIPauseManager : MonoBehaviour
{
    public static sc_UIPauseManager Instance;

    public System.Action OnPause;

    public GameObject menuPause, inventaire, cameraGame, cameraPause;
    public GameObject[] Boutons;
    [SerializeField]
    private int optionSelected;

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
        optionSelected = 0;
        Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", true);
    }

    private void Update()
    {
        if (menuPause.activeInHierarchy || inventaire.activeInHierarchy)
        {
            bool mid = Physics.Raycast(player.position + Vector3.up * 1.5f, player.forward + player.right.normalized * 0.35f, 2f);
            bool TR = Physics.Raycast(player.position + Vector3.up * 1.5f, player.forward + Vector3.up * 0.4f + player.right.normalized * 0.80f, 2f);
            bool TL = Physics.Raycast(player.position + Vector3.up * 1.5f, player.forward + Vector3.up * 0.4f - player.right.normalized * 0.1f, 2f);
            bool BR = Physics.Raycast(player.position + Vector3.up * 1.5f, player.forward - Vector3.up * 0.4f + player.right.normalized * 0.80f, 2f);
            bool BL = Physics.Raycast(player.position + Vector3.up * 1.5f, player.forward - Vector3.up * 0.4f - player.right.normalized * 0.1f, 2f);
            if (mid || TR || TL || BR || BL)
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
        optionSelected = 0;
        Boutons[0].GetComponent<Animator>().SetBool("IsSelected", true);
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
        Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", false);
    }


    public void Quitter()
    {
        sc_PlayerManager_HC.Instance.IndexTerminal = -1;
        sc_DataManager.instance.SaveAll();
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            sc_GestionBlocs_HC.instance.SaveBlocs();
        }
        sc_SceneManager_HC.Instance.ChargeScene("MainMenu");
    }

    public void LoadInventory()
    {
        menuPause.transform.GetChild(2).GetComponent<Animator>().SetBool("IsSelected", false);
        menuPause.transform.GetChild(3).GetComponent<Animator>().SetBool("IsSelected", false);
        menuPause.transform.GetChild(4).GetComponent<Animator>().SetBool("IsSelected", false);
        Camera.main.gameObject.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = 0.15f;
        inventaire.SetActive(true);
        menuPause.SetActive(false);
        cameraPause.SetActive(false);
    }
    public void CloseInventory()
    {
        inventaire.SetActive(false);
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

    public void Up()
    {
        if (menuPause.activeInHierarchy)
        {
            Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", false);
            optionSelected -= 1;
            if (optionSelected < 0) { optionSelected = Boutons.Length - 1; }
            Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", true);
        }
    }
    public void Down()
    {
        if (menuPause.activeInHierarchy)
        {
            Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", false);
            optionSelected += 1;
            if (optionSelected >= Boutons.Length) { optionSelected = 0; }
            Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", true);
        }
    }
    public void Select()
    {
        if (menuPause.activeInHierarchy)
        {
            Boutons[optionSelected].GetComponent<Button>().onClick.Invoke();
        }
    }

    public void MouseButton(int nb)
    {
        Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", false);
        optionSelected = nb;
        Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", true);
    }
}
