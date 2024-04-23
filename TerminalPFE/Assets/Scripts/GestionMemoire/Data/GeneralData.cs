using UnityEngine;

[System.Serializable]
public class GeneralData
{
    public int lastSceneLoaded, indexterminal;
    public Vector3 LastPos;
    public Quaternion LastRot;
    public bool porteTuto0Ouverte, porteTuto1Ouverte, porteTuto2Ouverte, porteSortieOuverte, porteDirecteur, porteProd, SolCasse, tutoBody, hasSwitchedBody;
    public bool[] ItemsCollected;
    public bool porteSpam;
    public bool doc1, doc2, doc3;

    public GeneralData()
    {
        this.lastSceneLoaded = 0;
        this.indexterminal = -1;
        this.LastPos = Vector3.zero;
        this.LastRot = Quaternion.identity;
        this.porteTuto0Ouverte = false;
        this.porteTuto1Ouverte = false;
        this.porteTuto2Ouverte = false;
        this.porteSortieOuverte = false;
        this.porteDirecteur = false;
        this.porteProd = false;
        this.SolCasse = false;
        this.tutoBody = false;
        this.hasSwitchedBody = false;
        this.ItemsCollected = new bool[]{ false, false, false, false, false, false, false, false, false, false, false, false};
        this.porteSpam = false;
        this.doc1 = false;
        this.doc2 = false;
        this.doc3 = false;
    }
}
