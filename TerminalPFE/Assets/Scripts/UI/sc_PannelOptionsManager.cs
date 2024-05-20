using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class sc_PannelOptionsManager : MonoBehaviour
{
    public GameObject pannelGraphique, pannelSon, pannelControles;

    public Slider sliderSensiCam;
    public TMP_Text valeurGraphismes, valeurSensiCam;


    private void Awake()
    {
        sliderSensiCam.value = sc_DataManager.instance.settingsData.sensiCam;
        valeurSensiCam.text = sc_DataManager.instance.settingsData.sensiCam.ToString();
        QualitySettings.SetQualityLevel(sc_DataManager.instance.settingsData.quality);
        valeurGraphismes.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
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

    public void SwitchQuality(bool isGauche)
    {
        int i = QualitySettings.GetQualityLevel();
        if(isGauche)
        {
            if(i == 0)
            {
                i = QualitySettings.count - 1;
            }
            else
            {
                i--;
            }
        }
        else
        {
            if (i == QualitySettings.count -1)
            {
                i = 0;
            }
            else
            {
                i++;
            }
        }

        QualitySettings.SetQualityLevel(i);
        valeurGraphismes.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
        sc_DataManager.instance.SaveQuality(i);
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
