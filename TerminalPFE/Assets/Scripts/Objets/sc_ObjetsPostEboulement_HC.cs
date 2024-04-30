using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_ObjetsPostEboulement_HC : MonoBehaviour, IDataManager
{
    [Header("Le script s'active après qu'on sort de simu en ayant fait le passage corps cassé")]
    [Tooltip("Quel état l'objet aura")]
    public bool etatPostEboulement;
    [Tooltip("A cocher si l'objet ne doit pas apparaitre avant l'éboulement")]
    public bool estDesactiveAvantEboulement;

    public void LoadData(GeneralData data)
    {
        if (data.hasSwitchedBody)
        {
            gameObject.SetActive(etatPostEboulement);
        }
        else
        {
            if (estDesactiveAvantEboulement)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void SaveData(ref GeneralData data)
    {
    }
}
