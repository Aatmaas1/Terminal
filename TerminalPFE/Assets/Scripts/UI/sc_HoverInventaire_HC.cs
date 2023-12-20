using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class sc_HoverInventaire_HC : MonoBehaviour, IPointerEnterHandler
{
    public int index;
    public void OnPointerEnter(PointerEventData eventData)
    {
        sc_PreviewItem.Instance.Highlight(index);
        Debug.Log("aaa");
    }
}
