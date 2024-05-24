using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_PORTES_AM : MonoBehaviour
{
    public AK.Wwise.Event open;
    public AK.Wwise.Event close;
    public AK.Wwise.Event changeLight;

    public AkRoomPortal portal;

    public void OpenPortal()
    {


        if (portal != null)
        {
            portal.Open();
        }
    }

    public void ClosePortal()
    {

        if (portal != null)
        {
            portal.Close();
        }
    }

    public void Open()
    {        
        open.Post(gameObject);
        //Debug.Log("Je m'ouvre");
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
