using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class sc_AL_TriggerFin : MonoBehaviour
{
    public GameObject PanelFinRough;
    public Animator cameraEndPlayer;
    public GameObject cameraEndCinemachine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DeclencheUIEnd());
            cameraEndPlayer.SetTrigger("End");
            //cameraEndCinemachine.SetActive(true);
            other.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
            Cursor.lockState = CursorLockMode.None;
        }
    }

    IEnumerator DeclencheUIEnd()
    {
        yield return new WaitForSeconds(5f);
            PanelFinRough.SetActive(true);

    }
}
