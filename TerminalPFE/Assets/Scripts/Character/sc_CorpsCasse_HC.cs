using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_CorpsCasse_HC : MonoBehaviour, IDataManager
{
    public GameObject CorpsDeBase, newCamFollow, CamFollowBase;

    public void LoadData(GeneralData data)
    {
        if(data.SolCasse && !data.hasSwitchedBody)
        {
            BreakLegs();
        }
    }

    public void SaveData(ref GeneralData data)
    {
        //throw new System.NotImplementedException();
    }

    public void BreakLegs()
    {
        CorpsDeBase.SetActive(false);
        CamFollowBase.SetActive(false);
        gameObject.SetActive(true);
        newCamFollow.SetActive(true);
    }
}
