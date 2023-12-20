using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

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
        SceneManager.activeSceneChanged += SceneChanged;
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
        this.dataInterfaceObjects = FindAllDataInterfaceObjects();
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


    void SceneChanged(Scene current, Scene next)
    {
        this.dataInterfaceObjects = FindAllDataInterfaceObjects();
        LoadToObjects();
    }


    public void ForceSaveIndex(int index)
    {
        generalData.indexterminal = index;
    }

    public void ForceSaveLastScene(int index)
    {
        generalData.lastSceneLoaded = index;
    }

    public int WhatIsLastScene()
    {
        return generalData.lastSceneLoaded;
    }
}
