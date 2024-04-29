using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroyed : MonoBehaviour, IDataManager
{
    bool isBroken = false;
    public GameObject BatterieLow;
    public GameObject BatterieLowUI;
    public Animator animator;
    public Animator PlayerAnimator;
    public Animator EcranNoir;
    public sc_CorpsCasse_HC RobotCasse;

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

            sc_DataManager.instance.CasseSol();
            // on détruit cet objet après la 1ere utilisation pour ne plus qu'il aparaisse
            //Destroy(this.gameObject);
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

                RobotCasse.BreakLegs();
                
            }
            StartCoroutine(WaitForSecondsToDestroyTheGameObject());
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
        BatterieLow.GetComponent<Animator>().SetTrigger("Reel");
        BatterieLowUI.SetActive(true);
        
    }
    IEnumerator WaitAnimFall()
    {
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        yield return new WaitForSeconds(2.4f);
        EcranNoir.Play("FadeIn");
        yield return new WaitForSeconds(0.5f);
        PlayerAnimator.GetComponent<Animator>().SetTrigger("StopFall");
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
        RobotCasse.BreakLegs();
        yield return new WaitForSeconds(1.5f);
        EcranNoir.Play("FadeOut");
    }
    
    IEnumerator WaitForSecondsToDestroyTheGameObject()
    {
        yield return new WaitForSeconds(10f);
        // on détruit cet objet après la 1ere utilisation pour ne plus qu'il aparaisse
        Destroy(this.gameObject);
    }
}
