using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroyed : MonoBehaviour, IDataManager
{
    bool isBroken = false;
    public GameObject BatterieLow;
    public Animator animator;
    public  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isBroken = true;
            // transform.parent.gameObject.SetActive(false);
            animator.GetComponent<Animator>().SetTrigger("Destroy");
            sc_ScreenShake.instance.ScreenHardLong();
            StartCoroutine("WaitBeforeBatterie");


        }
    }

    public void LoadData(GeneralData data)
    {
        if (data.SolCasse)
        {
            isBroken = true;
            transform.parent.gameObject.SetActive(false);
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
}
