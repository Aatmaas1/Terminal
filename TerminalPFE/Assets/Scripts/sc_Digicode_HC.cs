using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sc_Digicode_HC : MonoBehaviour
{
    public string Code;
    public TMP_Text Affichage;
    public GameObject Visuel, CamPerso, CamCode, VisuRobot;

    string memory = "";
    bool _canAct = true;

    public void Open()
    {
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Visuel.SetActive(true);
        VisuRobot.SetActive(false);
        CamPerso.SetActive(false);
        CamCode.SetActive(true);
    }
    public void Close()
    {
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Visuel.SetActive(false);
        VisuRobot.SetActive(true);
        CamCode.SetActive(false);
        CamPerso.SetActive(true);
        DeleteAll();
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
        _canAct = false;
        Affichage.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        DeleteAll();
        _canAct = true;
        Affichage.color = Color.white;
    }
}
