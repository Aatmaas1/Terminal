using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroyed : MonoBehaviour, IDataManager
{
    bool isBroken = false;

    public Animator animator;
    public  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isBroken = true;
            // transform.parent.gameObject.SetActive(false);
            animator.GetComponent<Animator>().SetTrigger("Destroy");
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
}
