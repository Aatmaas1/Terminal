using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[System.Serializable]
public class GeneralData
{
    public int lastSceneLoaded, indexterminal;
    public Transform LastPos;
    public bool porteTuto1Ouverte, porteTuto2Ouverte, porteSortieOuverte, SolCasse, hasSwitchedBody;


    public GeneralData()
    {
        this.lastSceneLoaded = 0;
        this.indexterminal = -1;
        this.LastPos = null;
        this.porteTuto1Ouverte = false;
        this.porteTuto2Ouverte = false;
        this.porteSortieOuverte = false;
        this.SolCasse = false;
        this.hasSwitchedBody = false;
    }
}
