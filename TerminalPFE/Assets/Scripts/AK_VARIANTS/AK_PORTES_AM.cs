using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_PORTES_AM : MonoBehaviour
{
    public AK.Wwise.Event open;
    public AK.Wwise.Event close;
    public AK.Wwise.Event changeLight;

    public GameObject portal;

    public void Open()
    {
        if (gameObject.name == "PorteUsine" && portal != null)
        {
            portal.SetActive(true);
        }
        open.Post(gameObject);
    }

    public void Close()
    {
        close.Post(gameObject);
    }

    public void ChangeLight()
    {
        changeLight.Post(gameObject);
    }
}
