using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_ChangeLightColor : MonoBehaviour
{
    public bool isOpen;

    public Material lightMat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
