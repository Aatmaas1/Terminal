using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class sc_PreviewItem : MonoBehaviour, IDataManager
{
    public static sc_PreviewItem Instance;

    public GameObject[] Cadres;
    public GameObject[] Models;
    public sc_SO_Memoire_HC[] IsObjects;
    public GameObject[] ImageItem;
    public TMP_Text Titre, description;

    public GameObject SelectedSlot, menuSelection;
    GameObject shownItem = null;
    public float rotateSpeed;

    int selected = 0;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        MajInv();
    }

    // Update is called once per frame
    void Update()
    {
        SelectedSlot.transform.position = Cadres[selected].transform.position;
    }


    public void LoadData(GeneralData data)
    {
        for (int temp = 0; temp < 12; temp++)
        {
            if (data.ItemsCollected[temp] == false)
            {
                ImageItem[temp].SetActive(false);
            }
            else
            {
                ImageItem[temp].SetActive(true);
            }

        }
    }

    public void SaveData(ref GeneralData data)
    {

    }

    public void OnUp()
    {
        if (ImageItem[selected].activeInHierarchy)
        {
            Cadres[selected].GetComponent<Animator>().SetBool("IsSelected", false);
        }
        selected -= 1;
        if (selected < 0) { selected = 11; }
        if (ImageItem[selected].activeInHierarchy)
        {
            Cadres[selected].GetComponent<Animator>().SetBool("IsSelected", true);
        }
    }
    public void OnDown()
    {
        if (ImageItem[selected].activeInHierarchy)
        {
            Cadres[selected].GetComponent<Animator>().SetBool("IsSelected", false);
        }
        selected += 1;
        if (selected > 11) { selected = 0; }
        if (ImageItem[selected].activeInHierarchy)
        {
            Cadres[selected].GetComponent<Animator>().SetBool("IsSelected", true);
        }
    }

    public void OnLeft()
    {
        if (ImageItem[selected].activeInHierarchy)
        {
            Cadres[selected].GetComponent<Animator>().SetBool("IsSelected", false);
        }
        OnBack();
        if (ImageItem[selected].activeInHierarchy)
        {
            Cadres[selected].GetComponent<Animator>().SetBool("IsSelected", true);
        }
    }

    public void OnRight()
    {
        if (ImageItem[selected].activeInHierarchy)
        {
            Cadres[selected].GetComponent<Animator>().SetBool("IsSelected", false);
        }
        OnInterract();
        if (ImageItem[selected].activeInHierarchy)
        {
            Cadres[selected].GetComponent<Animator>().SetBool("IsSelected", true);
        }
    }

    public void OnInterract()
    {
        if (ImageItem[selected].activeInHierarchy)
        {
            if (shownItem != null)
            {
                shownItem.transform.position -= Vector3.up * 20f;
            }
            description.gameObject.SetActive(true);
            shownItem = Models[selected];
            shownItem.transform.position += Vector3.up * 20f;
            Titre.text = IsObjects[selected].nom;
            description.text = IsObjects[selected].commentaireAndroid;
            description.transform.GetChild(0).GetComponent<TMP_Text>().text = IsObjects[selected].description;
        }
    }

    public void OnBack()
    {
        if (sc_UIPauseManager.Instance.inventaire.activeInHierarchy)
        {
            if (shownItem != null)
            {
                shownItem.transform.position -= Vector3.up * 20f;
                shownItem = null;
            }
            description.gameObject.SetActive(false);
            Titre.text = "Inventaire";
            Cursor.lockState = CursorLockMode.None;
            sc_UIPauseManager.Instance.CloseInventory();
        }
    }

    public void OnPause()
    {
        OnBack();
    }

    public void OnMoveObject(InputValue value)
    {
        if (shownItem != null)
        {
            if (Input.GetMouseButton(0))
            {
                shownItem.transform.Rotate(value.Get<Vector2>() * rotateSpeed);
            }
        }
    }

    public void Highlight(int nb)
    {
        if (ImageItem[selected].activeInHierarchy)
        {
            Cadres[selected].GetComponent<Animator>().SetBool("IsSelected", false);
        }
        selected = nb;
        if (ImageItem[selected].activeInHierarchy)
        {
            Cadres[selected].GetComponent<Animator>().SetBool("IsSelected", true);
        }
    }

    public void MajInv()
    {
        for (int i = 0; i < 12; i++)
        {
            ImageItem[i].GetComponent<TMP_Text>().text = IsObjects[i].nom;
        }
    }
}
