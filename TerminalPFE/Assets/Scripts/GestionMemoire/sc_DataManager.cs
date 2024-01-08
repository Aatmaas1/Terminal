using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class sc_DataManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;




    public static sc_DataManager instance { get; private set; }

    private GeneralData generalData;

    private List<IDataManager> dataInterfaceObjects;

    private sc_FileHandler_HC fileHandler;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Plus d'un sc_DataManager trouvé, destruction du duplicata");
            Destroy(this);
        }
        instance = this;
        //DontDestroyOnLoad(this);
    }

    private void Start()
    {
        this.fileHandler = new sc_FileHandler_HC(Application.persistentDataPath, fileName);
        this.dataInterfaceObjects = FindAllDataInterfaceObjects();
        LoadAll();
    }



    public void NewGame()
    {
        this.generalData = new GeneralData();
    }

    public void LoadAll()
    {
        // Load all the saves using dataHandler
        this.generalData = fileHandler.Load();

        // if there isn't any, create a new save
        if(this.generalData == null)
        {
            Debug.Log("No Data found, creating a new save file.");
            NewGame();
        }

        //Pass it to the scripts
        LoadToObjects();
    }

    public void SaveAll()
    {
        //this.dataInterfaceObjects = FindAllDataInterfaceObjects();
        //pass data to other scripts to handle it
        foreach (IDataManager interf in dataInterfaceObjects)
        {
            interf.SaveData(ref generalData);
        }

        //Save data with dataHandler
        fileHandler.Save(generalData);
    }

    public void LoadToObjects()
    {
        foreach (IDataManager interf in dataInterfaceObjects)
        {
            interf.LoadData(generalData);
        }
    }



    private void OnApplicationQuit()
    {
        SaveAll();
    }


    private List<IDataManager> FindAllDataInterfaceObjects()
    {
        IEnumerable<IDataManager> datapersistenceobjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataManager>();

        return new List<IDataManager>(datapersistenceobjects);
    }


    public void ForceSaveIndex(int index)
    {
        generalData.indexterminal = index;
        fileHandler.Save(generalData);
    }

    public void ForceSaveLastScene(int index)
    {
        generalData.lastSceneLoaded = index;
        fileHandler.Save(generalData);
    }

    public int WhatIsLastScene()
    {
        return generalData.lastSceneLoaded;
        fileHandler.Save(generalData);
    }

    public void MoveRobotTuto(bool ya)
    {
        generalData.tutoBody = ya;
        fileHandler.Save(generalData);
    }

    public void MoveRobotCorpse()
    {
        generalData.hasSwitchedBody = true;
        fileHandler.Save(generalData);
    }
}
