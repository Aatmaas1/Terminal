using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class sc_Digicode_HC : MonoBehaviour
{
    public string Code;
    public TMP_Text Affichage;
    public GameObject Visuel, CamPerso, CamCode, VisuRobot, skeleRobot;
    public Color colorError;

    string memory = "";
    bool _canAct = true;

    public void Open()
    {
        AudioListenerDontDestroyOnLoad.instance.Code();
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        Visuel.SetActive(true);
        VisuRobot.SetActive(false);
        skeleRobot.SetActive(false);
        CamPerso.SetActive(false);
        CamCode.SetActive(true);
    }
    public void Close()
    {
        if(Visuel.activeInHierarchy)
        {
            AudioListenerDontDestroyOnLoad.instance.StopCode();
            sc_PlayerManager_HC.Instance.SetInputMode("Player");
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            Visuel.SetActive(false);
            VisuRobot.SetActive(true);
            skeleRobot.SetActive(true);
            CamCode.SetActive(false);
            CamPerso.SetActive(true);
            DeleteAll();
        }
    }

    public void BoutonChiffre(string index)
    {
        if (_canAct)
        {
            memory += index;
            UpdateText();
            if (memory.Length == 4)
            {
                Check();
            }
        }
    }

    public void DeleteOne()
    {
        memory = memory.Remove(memory.Length - 1);
        UpdateText();
    }

    public void DeleteAll()
    {
        memory = "";
        UpdateText();
    }


    void Check()
    {
        if(memory == Code)
        {
            transform.parent.GetComponent<Bouton>().AppelDigicode();
            Close();
        }
        else
        {
            StartCoroutine(DelayReset());
            //TODO - Faire une anim
        }
    }

    void UpdateText()
    {
        Affichage.text = memory;
    }

    IEnumerator DelayReset()
    {
        Color tempc = Affichage.transform.parent.GetComponent<Image>().color;
        //Color textc = Affichage.color;
        _canAct = false;
        //Affichage.color = Color.black;
        Affichage.transform.parent.GetComponent<Image>().color = colorError;
        memory = "XXXX";
        UpdateText();
        yield return new WaitForSeconds(0.5f);
        DeleteAll();
        _canAct = true;
        //Affichage.color = textc;
        Affichage.transform.parent.GetComponent<Image>().color = tempc;
    }
}
