using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_BoutpnRetour_HC : MonoBehaviour
{
    public GameObject pannel;

    public void Change()
    {
        pannel.SetActive(!pannel.activeInHierarchy);
    }
}
