using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_DeathBox_HC : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sc_PlayerManager_HC.Instance.Respawn();
        }
    }
}
