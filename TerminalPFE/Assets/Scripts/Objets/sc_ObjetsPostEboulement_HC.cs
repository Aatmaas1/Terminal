using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_ObjetsPostEboulement_HC : MonoBehaviour, IDataManager
{
    [Header("Le script s'active apr�s qu'on sort de simu en ayant fait le passage corps cass�")]
    [Tooltip("Quel �tat l'objet aura")]
    public bool etatPostEboulement;
    [Tooltip("A cocher si l'objet ne doit pas apparaitre avant l'�boulement")]
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
