using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class sc_PannelOptionsManager : MonoBehaviour
{
    public GameObject pannelGraphique, pannelSon, pannelControles;

    public Slider sliderSensiCam;
    public TMP_Text valeurSensiCam;


    private void Start()
    {
        sliderSensiCam.value = sc_DataManager.instance.settingsData.sensiCam;
        valeurSensiCam.text = sc_DataManager.instance.settingsData.sensiCam.ToString();
    }

    public void OpenVisual()
    {
        CloseAllPannels();
        pannelGraphique.SetActive(true);
    }
    public void OpenSon()
    {
        CloseAllPannels();
        pannelSon.SetActive(true);
    }
    public void OpenControles()
    {
        CloseAllPannels();
        pannelControles.SetActive(true);
    }
    public void CloseAllPannels()
    {
        pannelSon.SetActive(false);
        pannelControles.SetActive(false);
        pannelGraphique.SetActive(false);
    }

    public void SwitchQualiy(bool isGauche)
    {
        /*if(isGauche)
        {

        }
        else
        {

        }*/
    }

    public void ChangeSensiCam()
    {
        sc_DataManager.instance.SaveCamSensi(sliderSensiCam.value);
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            sc_PlayerManager_HC.Instance.SetSensiCam(sliderSensiCam.value);
        }
        valeurSensiCam.text = sc_DataManager.instance.settingsData.sensiCam.ToString();
    }
}
