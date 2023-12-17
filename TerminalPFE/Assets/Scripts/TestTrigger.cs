using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TestTrigger : MonoBehaviour
{
    public UnityEvent OnTrig;
    public int index;
    public GameObject playerAvatarSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sc_InGameMemory_HC.Instance.IndexTerminal = index;
            other.GetComponent<PlayerInput>().DeactivateInput();
            OnTrig?.Invoke();
            transform.position = new Vector3(0, -5000, 0);
        }
    }

    public void SpawnPlayer()
    {
        sc_PlayerManager_HC.Instance.GetComponent<CharacterController>().enabled = false;
        sc_PlayerManager_HC.Instance.transform.position = playerAvatarSpawn.transform.position;
        sc_PlayerManager_HC.Instance.transform.rotation = playerAvatarSpawn.transform.rotation;
        sc_PlayerManager_HC.Instance.GetComponent<CharacterController>().enabled = true;
    }
}
