using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_TriggerTuto_HC : MonoBehaviour
{
    public int index;
    bool isUsed = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !isUsed)
        {
            isUsed = true;
            sc_TutoManager_HC.Instance.TriggerActivated(index);
            Debug.Log("Bye");
            gameObject.SetActive(false);
        }
    }
}
