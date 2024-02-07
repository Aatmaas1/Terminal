using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_OTEPLAYER_AM : AkTriggerCollisionEnter
{
    private void OnCollisionEnter(UnityEngine.Collision in_other)
    {
        if (in_other != null && in_other.collider.CompareTag("Player"))
        {
            if (triggerDelegate != null && (triggerObject == null || triggerObject == in_other.gameObject))
                triggerDelegate(in_other.gameObject);
        }
    }

    private void OnTriggerEnter(UnityEngine.Collider in_other)
    {
        if (in_other != null && in_other.CompareTag("Player"))
        {
            if (triggerDelegate != null && (triggerObject == null || triggerObject == in_other.gameObject))
                triggerDelegate(in_other.gameObject);
        }
    }
}
