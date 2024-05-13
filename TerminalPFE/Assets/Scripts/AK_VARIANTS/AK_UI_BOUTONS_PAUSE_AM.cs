using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_UI_BOUTONS_PAUSE_AM : MonoBehaviour
{
    public AK.Wwise.Event onCursor;

    public AK.Wwise.Event onClick;

    private void OnMouseEnter()
    {
        onCursor.Post(gameObject);
    }

    private void OnMouseDown()
    {
        onClick.Post(gameObject);
    }
}
