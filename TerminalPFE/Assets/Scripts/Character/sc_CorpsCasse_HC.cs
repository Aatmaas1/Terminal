using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
