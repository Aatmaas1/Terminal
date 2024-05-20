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
    public SettingsData settingsData;

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
        this.fileHandler = new sc_FileHandler_HC(Application.persistentDataPath, fileName);
        this.dataInterfaceObjects = FindAllDataInterfaceObjects();
        LoadAll();
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("reset");
            NewGame();
            fileHandler.Save(generalData);
            LoadAll();
        }
    }*/


    public void NewGame()
    {
        this.generalData = new GeneralData();
        fileHandler.Save(generalData);
        sc_FileHandler_HC a = new sc_FileHandler_HC(Application.persistentDataPath, "Cubes.game");
        a.SaveBlocks(new BlocsSimu());
    }

    public void LoadAll()
    {
        // Load all the saves using dataHandler
        this.generalData = fileHandler.Load();
        this.settingsData = fileHandler.LoadSettings();

        // if there isn't any, create a new save
        if(this.generalData == null)
        {
            Debug.Log("No Data found, creating a new save file.");
            NewGame();
        }

        if(this.settingsData == null)
        {
            settingsData = new SettingsData();
            fileHandler.SaveSettings(settingsData);
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
        fileHandler.SaveSettings(settingsData);
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

    public void SaveObject(int index, bool state)
    {
        generalData.ItemsCollected[index] = state;
        fileHandler.Save(generalData);
        sc_PreviewItem.Instance.LoadData(generalData);
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

    public bool TestIsNewSave()
    {
        if(generalData.LastPos == Vector3.zero)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheatCode()
    {
        NewGame();
        generalData.lastSceneLoaded = 1;
        generalData.indexterminal = -1;
        generalData.LastPos = new Vector3(57, 0, 4);
        generalData.LastRot = new Quaternion(0, 0.637f, 0, 0.77f);
        for(int i = 0; i<12; i++)
        {
            generalData.ItemsCollected[i] = true;
        }
        generalData.porteTuto0Ouverte = true;
        generalData.porteTuto1Ouverte = true;
        generalData.porteTuto2Ouverte = true;
    }

    public void CasseSol()
    {
        generalData.SolCasse = true;
    }

    public bool TestCasse()
    {
        return generalData.SolCasse && !generalData.hasSwitchedBody;
    }

    public bool CheckID(int index)
    {
        if (index == 1)
        {
            return generalData.ItemsCollected[0];
        }
        else if (index == 2)
        {
            return generalData.ItemsCollected[8];
        }
        else if (index == 3)
        {
            return generalData.ItemsCollected[10];
        }
        else { return false; }
    }

    public void SaveRobotColor(bool arm, bool leg)
    {
        generalData.redArm = arm;
        generalData.redLeg = leg;
    }

    public void SaveCamSensi(float sensi)
    {
        settingsData.sensiCam = sensi;
        fileHandler.SaveSettings(settingsData);
    }
    public void SaveQuality(int valeur)
    {
        settingsData.quality = valeur;
        fileHandler.SaveSettings(settingsData);
    }
}
