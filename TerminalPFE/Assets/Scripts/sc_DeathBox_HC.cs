using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_DeathBox_HC : MonoBehaviour
{
    public float dureeAnim;
    Quaternion memRotation;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
            memRotation = other.transform.rotation;
            other.GetComponent<Animator>().Play("MortSimu");
            StartCoroutine(DelayAnim());
        }
    }

    IEnumerator DelayAnim()
    {
        yield return new WaitForSeconds(dureeAnim);
        sc_PlayerManager_HC.Instance.LanceAnimRespawn();
        sc_PlayerManager_HC.Instance.Respawn();
    }
}
