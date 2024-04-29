using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_PORTES_AM : MonoBehaviour
{
    public AK.Wwise.Event open;
    public AK.Wwise.Event close;
    public AK.Wwise.Event changeLight;

    public AkRoomPortal portal;

    public void Open()
    {
        if(portal != null)
        {
            portal.Open();
        }
        
        open.Post(gameObject);
        //Debug.Log("Je m'ouvre");
    }

    public void Close()
    {
        close.Post(gameObject);

        if (portal != null)
        {
            portal.Close();
        }

    }

    public void ChangeLight()
    {
        changeLight.Post(gameObject);
    }
}
