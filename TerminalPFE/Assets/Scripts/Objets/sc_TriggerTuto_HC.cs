using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class sc_TriggerTuto_HC : MonoBehaviour
{
    public int index;
    bool isUsed = false;
    VisualEffect _ZoneVFX;
    bool alreadyActivated;

    private void Start()
    {
        _ZoneVFX = GetComponent<VisualEffect>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !isUsed)
        {
            isUsed = true;
            sc_TutoManager_HC.Instance.TriggerActivated(index);
            if(_ZoneVFX != null && !alreadyActivated)
            {
                _ZoneVFX.SendEvent("OnEnter");
                _ZoneVFX.SetFloat("ColorChanger", 1);
                alreadyActivated = true;
            }
            StartCoroutine(Disable());
        }
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
