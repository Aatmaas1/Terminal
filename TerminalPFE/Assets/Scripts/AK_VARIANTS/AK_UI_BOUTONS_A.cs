using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AK_UI_BOUTONS_A : MonoBehaviour
{
    public AK.Wwise.Event onCursor;

    public AK.Wwise.Event onClick;

    [HideInInspector] public Button button;

    [HideInInspector] public bool isSelected;

    private void Start()
    {
        button = GetComponent<Button>();       
    }

    private void OnMouseEnter()
    {
        if (onCursor != null && isSelected == false)
        {
            PointerEnter();
            isSelected = true;
        }
    }

    private void OnMouseDown()
    {
        if(onClick != null)
        {
            PointerClick();
        }       
    }

    private void OnMouseExit()
    {
        isSelected = false;
    }


    public void PointerEnter()
    {
        onCursor.Post(gameObject);
    }

    public void PointerClick()
    {
        onClick.Post(gameObject);
    }
}
