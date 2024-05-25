using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class sc_AnimBoutonPause_HC : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int index = -1;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(index >= 0)
        {
            sc_UIPauseManager.Instance.MouseButton(index);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsSelected", true);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (index < 0)
        {
            GetComponent<Animator>().SetBool("IsSelected", false);
        }
    }
}
