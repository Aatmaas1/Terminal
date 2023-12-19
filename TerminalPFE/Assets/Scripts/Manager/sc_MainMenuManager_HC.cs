using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class sc_MainMenuManager_HC : MonoBehaviour
{
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
        yield return new WaitForSeconds(2f);
        _controlsLocked = false;
    }

    void SetPoints()
    {
        PointGauche.transform.position = Boutons[optionSelected].transform.position + Vector3.left * 180;
        PointDroite.transform.position = Boutons[optionSelected].transform.position + Vector3.right * 180;
    }

    public void OnUp()
    {
        if (!_controlsLocked)
        {
            optionSelected -= 1;
            if(optionSelected < 0) { optionSelected = Boutons.Length - 1; }
            SetPoints();
        }
    }

    public void OnDown()
    {
        if (!_controlsLocked)
        {
            optionSelected += 1;
            if (optionSelected >= Boutons.Length) { optionSelected = 0; }
            SetPoints();
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
        optionSelected = bout;
        SetPoints();
    }
}
