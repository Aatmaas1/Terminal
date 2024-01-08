using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_RobotControl : MonoBehaviour, IDataManager
{
    public bool isTuto = false;
    public bool isAtTheEnd;


    public void LoadData(GeneralData data)
    {
        if (isTuto)
        {
            if (isAtTheEnd)
            {
                if (data.hasSwitchedBody)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
            }
            else
            {
                if (data.hasSwitchedBody)
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (isAtTheEnd)
            {
                if (data.tutoBody)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
            }
            else
            {
                if (data.tutoBody)
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }

            }

        }
    }

    public void SaveData(ref GeneralData data)
    {
        
    }
}
