using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class sc_AL_TriggerFin : MonoBehaviour
{
    public GameObject PanelFinRough;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PanelFinRough.SetActive(true);
            other.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
