using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_OTE_AM : AkTriggerCollisionEnter
{
    private void OnCollisionEnter(UnityEngine.Collision in_other)
    {
        if (in_other != null && in_other.collider.CompareTag("Walkable"))
        {
            if (triggerDelegate != null && (triggerObject == null || triggerObject == in_other.gameObject))
                triggerDelegate(in_other.gameObject);
        }
    }

    private void OnTriggerEnter(UnityEngine.Collider in_other)
    {
        if (triggerDelegate != null && (triggerObject == null || triggerObject == in_other.gameObject))
            triggerDelegate(in_other.gameObject);
    }
}
