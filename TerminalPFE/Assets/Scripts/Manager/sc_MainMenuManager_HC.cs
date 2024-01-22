using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public class sc_MainMenuManager_HC : MonoBehaviour
{
    public bool hasPorte;
    public GameObject CachePorte, TextePressAnyButton;
    public GameObject[] Boutons;
    public GameObject PointGauche, PointDroite;

    private bool _hasFirstPressed = false;
    [SerializeField]
    private bool _controlsLocked = true;
    [SerializeField]
    private int optionSelected;
    // Start is called before the first frame update
    void Start()
    {
        optionSelected = 0;
        SetPoints();
        Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", true);
        if (!hasPorte)
        {
            _hasFirstPressed = true;
            CachePorte.SetActive(false);
            TextePressAnyButton.SetActive(false);
            _controlsLocked = false;
            foreach (GameObject but in Boutons)
            {
                but.GetComponent<Button>().enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasFirstPressed)
        {
            InputSystem.onAnyButtonPress.CallOnce(ctrl => StartCoroutine(LaunchAnimPorte()));
        }
    }

    IEnumerator LaunchAnimPorte()
    {
        _hasFirstPressed = true;
        CachePorte.GetComponent<Animator>().SetBool("IsOpening", true);
        TextePressAnyButton.GetComponent<Animator>().Play("ActionPressButton");
        yield return new WaitForSeconds(1.2f);
        _controlsLocked = false;
        foreach(GameObject but in Boutons)
        {
            but.GetComponent<Button>().enabled = true;
        }
    }

    void SetPoints()
    {
        PointGauche.transform.position = Boutons[optionSelected].transform.position + Vector3.left * 180f / 14.8f;
        PointDroite.transform.position = Boutons[optionSelected].transform.position + Vector3.right * 180f / 14.8f;
    }

    public void OnUp()
    {
        if (!_controlsLocked)
        {
            Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", false);
            optionSelected -= 1;
            if(optionSelected < 0) { optionSelected = Boutons.Length - 1; }
            SetPoints();
            Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", true);
        }
    }

    public void OnDown()
    {
        if (!_controlsLocked)
        {
            Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", false);
            optionSelected += 1;
            if (optionSelected >= Boutons.Length) { optionSelected = 0; }
            SetPoints();
            Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", true);
        }
    }

    public void OnInterract()
    {
        if (!_controlsLocked)
        {
            if (Boutons[optionSelected].TryGetComponent(out IBoutonsMainMenu_HC j))
            {
                j.IsClicked();
            }
        }
    }

    public void BoutonHover(int bout)
    {
        Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", false);
        optionSelected = bout;
        SetPoints();
        Boutons[optionSelected].GetComponent<Animator>().SetBool("IsSelected", true);
    }
}
