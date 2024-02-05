using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_TriggerTuto_HC : MonoBehaviour
{
    public int index;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sc_TutoManager_HC.Instance.TriggerActivated(index);
        }
    }
}
