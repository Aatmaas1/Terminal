using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_CLOSEDOOR_AM : AkTriggerCollisionExit
{
    private ActionPorteTuto porteTuto;

    private AK_OPENDOOR_AM openDoor;

    [HideInInspector] public bool done = true;

    private void Start()
    {
        openDoor = GetComponent<AK_OPENDOOR_AM>();
        porteTuto = GetComponentInParent<ActionPorteTuto>();
        StartCoroutine(CoroutineVerif());
    }

    public void CloseDoor()
    {
        if (triggerDelegate != null)
            triggerDelegate(gameObject);
    }

    private IEnumerator CoroutineVerif()
    {
        if (porteTuto.isOpening == false && done == false)
        {
            CloseDoor();
            yield return new WaitForEndOfFrame();
            done = true;
            openDoor.done = false;
        }
        yield return new WaitForSecondsRealtime(1f);
        StartCoroutine(CoroutineVerif());
    }
}
