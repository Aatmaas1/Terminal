using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_OTE_AM : AkTriggerCollisionEnter
{
    bool isPlaying = false;

    private void OnCollisionEnter(UnityEngine.Collision in_other)
    {
        if (in_other != null && in_other.collider.CompareTag("Walkable") && isPlaying == false)
        {
            if (triggerDelegate != null && (triggerObject == null || triggerObject == in_other.gameObject))
                triggerDelegate(in_other.gameObject);

            StartCoroutine(ResetIsPlaying());
        }
    }

    private void OnTriggerEnter(UnityEngine.Collider in_other)
    {
        if (in_other != null && in_other.CompareTag("Walkable") && isPlaying == false)
        {
            if (triggerDelegate != null && (triggerObject == null || triggerObject == in_other.gameObject))
                triggerDelegate(in_other.gameObject);

            StartCoroutine(ResetIsPlaying());
        }
    }

    IEnumerator ResetIsPlaying()
    {
        isPlaying = true;
        yield return new WaitForSecondsRealtime(0.5f);
        isPlaying = false;
    }
}
