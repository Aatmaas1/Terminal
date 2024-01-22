using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_OPENDOOR_AM : AkTriggerCollisionEnter
{
    private ActionPorteTuto porteTuto;

    private AK_CLOSEDOOR_AM closeDoor;

    [HideInInspector] public bool done = false;

    private void Start()
    {
        closeDoor = GetComponent<AK_CLOSEDOOR_AM>();
        porteTuto = GetComponentInParent<ActionPorteTuto>();
        StartCoroutine(CoroutineVerif());
    }

    public void OpenDoor()
    {
        if (triggerDelegate != null)
            triggerDelegate(gameObject);
    }

    private IEnumerator CoroutineVerif()
    {
        if(porteTuto.isOpening == true && done == false)
        {
            OpenDoor();
            yield return new WaitForEndOfFrame();
            done = true;
            closeDoor.done = false;
        }
        yield return new WaitForSecondsRealtime(1f);
        StartCoroutine(CoroutineVerif());
    }
}
