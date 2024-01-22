using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class sc_AnimBoutonPause_HC : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("IsSelected", true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Animator>().SetBool("IsSelected", false);
    }
}
