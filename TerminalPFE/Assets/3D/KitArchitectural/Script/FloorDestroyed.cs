using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloorDestroyed : MonoBehaviour, IDataManager
{
    bool isBroken = false;
    public GameObject BatterieLow;
    public GameObject BatterieLowUI;
    public Animator animator;
    public Animator PlayerAnimator;
    public Animator EcranNoir;
    public sc_CorpsCasse_HC RobotCasse;
    public GameObject ecranDead;

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
            StartCoroutine(DelayMort());
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
        //BatterieLowUI.SetActive(true);
        
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

    IEnumerator DelayMort()
    {
        yield return new WaitForSeconds(90f);
        ecranDead.SetActive(true);
        for(int i = 0; i<=100; i++)
        {
            ecranDead.GetComponent<Image>().color = new Color(0, 0, 0, i /100);
            ecranDead.transform.GetChild(1).GetComponent<TMP_Text>().color = new Color(0, 0, 0, i / 100);
            yield return new WaitForSeconds(0.01f);
        }
        ecranDead.transform.GetChild(0).gameObject.SetActive(true);
        BatterieLow.SetActive(false);
        BatterieLowUI.SetActive(false);
        sc_PlayerManager_HC.Instance.SetInputMode("UI");
        Cursor.lockState = CursorLockMode.None;
    }

    public void NewLife()
    {
        sc_DataManager.instance.NewGame();
        sc_SceneManager_HC.Instance.ChargeSceneNoLoad("Introduction");
    }
}
