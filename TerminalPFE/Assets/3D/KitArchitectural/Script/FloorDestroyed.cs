using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroyed : MonoBehaviour, IDataManager
{
    bool isBroken = false;
    public GameObject BatterieLow;
    public Animator animator;
    public Animator PlayerAnimator;
    
    public  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isBroken = true;
            animator.GetComponent<Animator>().SetTrigger("Destroy");
            PlayerAnimator.GetComponent<Animator>().SetTrigger("Fall");
            
            sc_ScreenShake.instance.ScreenHardLong();
            StartCoroutine("WaitBeforeBatterie");
            StartCoroutine(WaitAnimFall());


        }
    }

    public void LoadData(GeneralData data)
    {
        if (data.SolCasse)
        {
            isBroken = true;
            Debug.Log("recasse");
            animator.speed = 20f;
            animator.GetComponent<Animator>().SetTrigger("Destroy");
            if(!data.hasSwitchedBody)
            {
                BatterieLow.SetActive(true);
            }
        }
    }

    public void SaveData(ref GeneralData data)
    {
        data.SolCasse = isBroken;
    }

    IEnumerator WaitBeforeBatterie()
    {
        yield return new WaitForSeconds(3.5f);
        sc_ScreenShake.instance.FovBatterie();
        BatterieLow.SetActive(true);
        
    }
    IEnumerator WaitAnimFall()
    {
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        yield return new WaitForSeconds(2.5f);
        PlayerAnimator.GetComponent<Animator>().SetTrigger("StopFall");
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
    }
}
