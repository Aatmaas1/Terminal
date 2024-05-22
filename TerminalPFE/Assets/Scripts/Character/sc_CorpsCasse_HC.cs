using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class sc_CorpsCasse_HC : MonoBehaviour
{
    public static sc_CorpsCasse_HC instance;
    public GameObject CorpsDeBase, newCamFollow, CamFollowBase;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }

    public void launchInteractAnimation()
    {
        GetComponent<Animator>().Play("ZombieInteraction");
        PlayerInput pInput;
        if (gameObject.activeInHierarchy)
        {
            pInput = GetComponent<PlayerInput>();
            pInput.enabled = true;
            pInput.ActivateInput();
            if (pInput.currentActionMap == null)
            {
                pInput.currentActionMap = pInput.actions.actionMaps[0];
            }
            //pInput.currentActionMap.Disable();
            pInput.SwitchCurrentActionMap("Nothing");
            pInput.currentActionMap.Enable();
        }
    }
    public void BreakLegs()
    {
        CorpsDeBase.SetActive(false);
        CamFollowBase.SetActive(false);
        gameObject.SetActive(true);
        newCamFollow.SetActive(true);
        CorpsDeBase.transform.parent = gameObject.transform;
        CorpsDeBase.transform.position = transform.position;
    }
    public void OnClick()
    {
        if (gameObject.activeInHierarchy)
        {
            IEnumerable<I_Interactible> datapersistenceobjects = FindObjectsOfType<MonoBehaviour>().OfType<I_Interactible>();
            foreach (I_Interactible interf in datapersistenceobjects)
            {
                interf.PressedInteract();
            }
        }
    }
}
