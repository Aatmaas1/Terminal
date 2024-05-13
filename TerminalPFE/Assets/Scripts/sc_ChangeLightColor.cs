using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class sc_ChangeLightColor : MonoBehaviour
{
    public bool isOpen;
    public bool isOpening;

    //private Material lightMat;
    public List<Material> cableMast;

    public List<GameObject> calbes;

    float value = 0;
    float valueClose = 1;
    public float speed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        if (calbes.Count > 0)
        {
            for (int i = 0; i < calbes.Count; i++)
            {
                Material mat = calbes[i].GetComponent<LineRenderer>().materials[0];
                cableMast.Add(mat);
            }
        }
        //cableMat = calbe.GetComponent<LineRenderer>().materials[0];
    }

    public void ChangeLights(int lightIndex)
    {
        if (cableMast.Count > 0)
        {
            sc_ScreenShake.instance.ScreenBaseQuick();

            value = 0;
            valueClose = 1;
            index = lightIndex;
            StartCoroutine(ChangeCableColor());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ChangeCableColor()
    {
        if (!isOpen)
        {
            isOpening = true;

            float lerper = 0;

            while (lerper < 1)
            {
                float amount = Mathf.Lerp(0, 1, lerper);
                if (cableMast.Count > 0)
                {
                    foreach (Material mat in cableMast)
                    {
                        mat.SetFloat("_ColorChanger", amount);
                    }
                }
                lerper += Time.deltaTime;
                yield return null;
            }

            isOpen = true;

            sc_ScreenShake.instance.ScreenBaseQuick();

            //ChangeColor(index);
        }
        else if (isOpen)
        {
            isOpening = true;

            float lerper = 0;

            while (lerper < 1)
            {
                float amount = Mathf.Lerp(1, 0, lerper);
                if (cableMast.Count > 0)
                {
                    foreach (Material mat in cableMast)
                    {
                        mat.SetFloat("_ColorChanger", amount);
                    }
                }
                lerper += Time.deltaTime;
                yield return null;
            }

            isOpen = false;

        }

    }

    /*
    public void ChangeColor(int indexMat)
    {
        //lightMat = GetComponent<MeshRenderer>().materials[indexMat];

        if (isOpen)//la porte est ouverte donc on ferme
        {
            //lightMat.SetFloat("_ColorChanger", 0);
            isOpen = false;
            //sc_ScreenShake.instance.ScreenBaseQuick();

        }

        else //la porte est fermée donc on ouvre
        {
            //lightMat.SetFloat("_ColorChanger", 1);
            isOpen = true;
            sc_ScreenShake.instance.ScreenBaseQuick();

        }
    }*/

}
