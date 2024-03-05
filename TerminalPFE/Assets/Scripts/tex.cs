using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class tex : MonoBehaviour
{
    /// Add a context menu named "Do Something" in the inspector
    /// of the attached script.
    [ContextMenu("Do Something")]
    void DoSomething()
    {
        sc_SimuTiles_LDOV[] myItems = FindObjectsOfType(typeof(sc_SimuTiles_LDOV)) as sc_SimuTiles_LDOV[];
        Debug.Log("Found " + myItems.Length + " instances with this script attached");
        int i = 0;
        foreach (sc_SimuTiles_LDOV item in myItems)
        {
            item.idBox = i;
            i++;
        }
        Debug.Log("done");
    }
}
