using UnityEngine;

[System.Serializable]
public class GeneralData
{
    public int lastSceneLoaded, indexterminal;
    public Vector3 LastPos;
    public Quaternion LastRot;
    public bool porteTuto1Ouverte, porteTuto2Ouverte, porteSortieOuverte, SolCasse, tutoBody, hasSwitchedBody;
    public bool[] ItemsCollected;

    public GeneralData()
    {
        this.lastSceneLoaded = 0;
        this.indexterminal = -1;
        this.LastPos = Vector3.zero;
        this.LastRot = Quaternion.identity;
        this.porteTuto1Ouverte = false;
        this.porteTuto2Ouverte = false;
        this.porteSortieOuverte = false;
        this.SolCasse = false;
        this.tutoBody = false;
        this.hasSwitchedBody = false;
        this.ItemsCollected = new bool[]{ false, false, false, false, false, false, false, false, false, false, false, false};
    }
}
