using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_GestionBlocs_HC : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;



    private BlocsSimu DataBlocs;

    private sc_FileHandler_HC fileHandler;


    private void Awake()
    {
        this.fileHandler = new sc_FileHandler_HC(Application.persistentDataPath, fileName);
        LoadAll();
    }
    public void NewGame()
    {
        this.DataBlocs = new BlocsSimu();
    }

    public void LoadAll()
    {
        // Load all the saves using dataHandler
        this.DataBlocs = fileHandler.Load();

        // if there isn't any, create a new save
        if (this.generalData == null)
        {
            Debug.Log("No Data found, creating a new save file.");
            NewGame();
        }

        //Pass it to the scripts
        LoadToObjects();
    }
}
