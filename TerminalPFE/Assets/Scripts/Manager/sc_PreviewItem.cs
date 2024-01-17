using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class sc_PreviewItem : MonoBehaviour, IDataManager
{
    public static sc_PreviewItem Instance;

    public GameObject[] Cadres;
    public GameObject[] Models;
    public GameObject[] ImageItem;
    public TMP_Text Titre;

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

        }
    }

    public void SaveData(ref GeneralData data)
    {

    }

    public void OnUp()
    {
        selected -= 1;
        if (selected < 0) { selected = 11; }
    }
    public void OnDown()
    {
        selected += 1;
        if (selected > 11) { selected = 0; }
    }

    public void OnLeft()
    {
        OnBack();
    }

    public void OnRight()
    {
        OnInterract();
    }

    public void OnInterract()
    {
        if (ImageItem[selected].activeInHierarchy)
        {
            if (shownItem != null)
            {
                shownItem.transform.position -= Vector3.up * 20f;
            }
            shownItem = Models[selected];
            shownItem.transform.position += Vector3.up * 20f;
            Titre.text = shownItem.name;
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
        selected = nb;
    }
}
