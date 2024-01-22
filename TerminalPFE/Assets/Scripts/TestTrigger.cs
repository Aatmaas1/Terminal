using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TestTrigger : MonoBehaviour
{
    public UnityEvent OnTrig;
    public int index;
    public GameObject playerAvatarSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sc_PlayerManager_HC.Instance.IndexTerminal = index;
            other.GetComponent<PlayerInput>().DeactivateInput();
            OnTrig?.Invoke();
            transform.position = new Vector3(0, -5000, 0);

            if(index == 1 && SceneManager.GetActiveScene().buildIndex == 2)
            {
                sc_DataManager.instance.MoveRobotTuto(false);
            }
            if (index == 2 && SceneManager.GetActiveScene().buildIndex == 2)
            {
                sc_DataManager.instance.MoveRobotTuto(true);
            }
            if (index == 3)
            {
                sc_DataManager.instance.MoveRobotCorpse();
            }
        }
    }
}
