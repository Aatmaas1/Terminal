using System.Collections;
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
            sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        }
    }

    IEnumerator DeclencheUIEnd()
    {
        yield return new WaitForSeconds(5f);
        PanelFinRough.SetActive(true);
        yield return new WaitForSeconds(30f);
        sc_PlayerManager_HC.Instance.SetInputMode("UI");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
