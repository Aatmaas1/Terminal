using UnityEngine;
using UnityEngine.InputSystem;

public class sc_PreviewItem : MonoBehaviour, IDataManager
{
    public static sc_PreviewItem Instance;

    public GameObject[] Cadres;
    public GameObject[] Models;
    public GameObject[] ImageItem;

    public GameObject SelectedSlot, menuSelection;
    GameObject shownItem = null;
    bool isShowing = false;
    public float rotateSpeed;

    int hauteur = 0;
    int largeur = 0;



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
        SelectedSlot.transform.position = Cadres[hauteur * 4 + largeur].transform.position;
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

    public void OnInterract()
    {
        if (!isShowing)
        {
            if(ImageItem[hauteur * 4 + largeur].activeInHierarchy)
            {
                isShowing = true; ;
                menuSelection.SetActive(false);
                shownItem = Models[hauteur * 4 + largeur];
                shownItem.transform.position += Vector3.up * 20f;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void OnBack()
    {
        if(isShowing)
        {
            shownItem.transform.position -= Vector3.up * 20f;
            shownItem = null;
            menuSelection.SetActive(true);
            isShowing = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Retour();
        }
    }

    public void OnMoveObject(InputValue value)
    {
        if (isShowing)
        {
            shownItem.transform.Rotate(value.Get<Vector2>() * rotateSpeed);
        }
    }


    public void Retour()
    {
        if (sc_DataManager.instance.WhatIsLastScene() == 1)
        {
            sc_SceneManager_HC.Instance.ChargeScene("LevelDesignReel");
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            sc_SceneManager_HC.Instance.ChargeScene("LevelDesignSimu");
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Highlight(int nb)
    {
        hauteur = Mathf.FloorToInt(nb / 4f);
        largeur = nb % 4;
    }
}
