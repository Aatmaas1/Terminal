using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_PannelOptionsManager : MonoBehaviour
{
    public GameObject pannelGraphique, pannelSon;


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
    public void CloseAllPannels()
    {
        pannelSon.SetActive(false);
        pannelGraphique.SetActive(false);
    }

    public void SwitchQualiy(bool isGauche)
    {
        if(isGauche)
        {

        }
        else
        {

        }
    }
}
