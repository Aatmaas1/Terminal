using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sc_ChangeLightColor : MonoBehaviour
{
    public bool isOpen;
    public bool isOpening;

    private Material lightMat;
    private Material cableMat;

    public GameObject calbe;

    float value = 0;
    float valueClose = 1;
    public float speed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        if(calbe != null)
            cableMat = calbe.GetComponent<LineRenderer>().materials[0];
    }

    public void ChangeLights(int lightIndex)
    {
        if(cableMat != null) 
        {
            value = 0;
            valueClose = 1; 
            index = lightIndex;
            StartCoroutine(ChangeCableColor());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening && !isOpen)
        {
            value = Mathf.MoveTowards(value, 1, Time.deltaTime * speed);
            cableMat.SetFloat("_ColorChanger", value);
        }
        else if (!isOpening && isOpen)
        {
            valueClose = Mathf.MoveTowards(valueClose, 0, Time.deltaTime * speed);
            cableMat.SetFloat("_ColorChanger", valueClose);
        }
    }

    IEnumerator ChangeCableColor()
    {
        if (!isOpen)
        {
            isOpening = true;

            yield return new WaitUntil(() => value >= 1);

            ChangeColor(index);
        }
        else if (isOpen)
        {
            isOpening = false;

            yield return new WaitUntil(() => value >= 0);

            ChangeColor(index);
        }

    }

    public void ChangeColor(int indexMat)
    {
        lightMat = GetComponent<MeshRenderer>().materials[indexMat];

        if (isOpen)//la porte est ouverte donc on ferme
        {
            lightMat.SetFloat("_ColorChanger", 0);
            isOpen = false;
        }

        else //la porte est fermée donc on ouvre
        {
            lightMat.SetFloat("_ColorChanger", 1);
            isOpen = true;
        }
    }

}
