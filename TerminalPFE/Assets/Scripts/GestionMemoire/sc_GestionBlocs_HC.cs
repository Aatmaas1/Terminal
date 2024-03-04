using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_GestionBlocs_HC : MonoBehaviour
{
    public static sc_GestionBlocs_HC instance;
    [Header("File Storage Config")]
    [SerializeField] private string fileName;



    private BlocsSimu DataBlocs;

    private sc_FileHandler_HC fileHandler;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        this.fileHandler = new sc_FileHandler_HC(Application.persistentDataPath, fileName);
    }
    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            LoadAll();
        }
    }

    public void NewGame()
    {
        this.DataBlocs = new BlocsSimu();
    }

    public void LoadAll()
    {
        // Load all the saves using dataHandler
        this.DataBlocs = fileHandler.LoadBlocks();

        // if there isn't any, create a new save
        if (this.DataBlocs == null)
        {
            Debug.Log("No Data found, creating a new save file.");
            NewGame();
        }

        //Pass it to the scripts
        LoadToBlocks();
    }

    public void LoadToBlocks()
    {
        //sc_SimuTiles_LDOV[] myItems = FindObjectsOfType(typeof(sc_SimuTiles_LDOV)) as sc_SimuTiles_LDOV[];
        //Debug.Log("Found " + myItems.Length + " instances with this script attached");
        /*foreach (sc_SimuTiles_LDOV item in myItems)
        {
            if (DataBlocs.blocs[item.idBox] == true)
            {
                item.StartTrigger();
            }
        }*/
        int i = 0;
        foreach (Transform child in transform)
        {
            if (child.GetChild(0).GetComponent<sc_SimuTiles_LDOV>())
            {
                sc_SimuTiles_LDOV tested = child.GetChild(0).GetComponent<sc_SimuTiles_LDOV>();
                if (DataBlocs.blocs[i] == true)
                {
                    tested.StartTrigger();
                }
                i++;
            }
        }
    }

    public void SaveBlocs()
    {
        //sc_SimuTiles_LDOV[] myItems = FindObjectsOfType(typeof(sc_SimuTiles_LDOV)) as sc_SimuTiles_LDOV[];
        int i = 0;
        foreach(Transform child in transform)
        {
            if (child.GetChild(0).GetComponent<sc_SimuTiles_LDOV>())
            {
                sc_SimuTiles_LDOV tested = child.GetChild(0).GetComponent<sc_SimuTiles_LDOV>();
                DataBlocs.blocs[i] = tested._touch;
                i++;
            }
        }
        /*foreach (sc_SimuTiles_LDOV item in myItems)
        {
            DataBlocs.blocs[item.idBox] = item._touch;
        }*/
        fileHandler.SaveBlocks(DataBlocs);
    }
}
