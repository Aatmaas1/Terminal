using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class sc_PreviewItem : MonoBehaviour, IDataManager
{
    public GameObject[] Cadres;
    public GameObject[] Models;

    public GameObject Selected;
    int hauteur = 0;
    int largeur = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Selected.transform.position = Cadres[hauteur*4+ largeur].transform.position;
    }


    public void LoadData(GeneralData data)
    {
        int temp = 0;
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j<3; j++)
            {
                if (data.ItemsCollected[temp] == false)
                {
                    Models[i*4+ j] = null;
                    temp++;
                }
            }
        }
    }

    public void SaveData(ref GeneralData data)
    {

    }

    public void OnUp()
    {
        hauteur -= 1;
        if (hauteur < 0) { hauteur = 2; }
    }
    public void OnDown()
    {
        hauteur += 1;
        if (hauteur > 2) { hauteur = 0; }
    }

    public void OnLeft()
    {
        largeur -= 1;
        if (largeur < 0) { largeur = 3; }
    }

    public void OnRight()
    {
        largeur += 1;
        if (largeur > 3) { largeur = 0; }
    }


    public void Retour()
    {
        if (sc_DataManager.instance.WhatIsLastScene() == 1)
        {
            sc_SceneManager_HC.Instance.ChargeScene("LevelDesignReel");
        }
        else
        {
            sc_SceneManager_HC.Instance.ChargeScene("LevelDesignSimu");
        }
    }
}
