using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_DeathBox_HC : MonoBehaviour
{
    public float dureeAnim;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
            other.GetComponent<Animator>().Play("MortSimu");
            StartCoroutine(DelayAnim());
        }
    }

    IEnumerator DelayAnim()
    {
        yield return new WaitForSeconds(dureeAnim);
        sc_PlayerManager_HC.Instance.Respawn();
        sc_PlayerManager_HC.Instance.LanceAnimRespawn();
    }
}
