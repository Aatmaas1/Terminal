using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class sc_NewDetection_LDOV : MonoBehaviour
{
    private AK_POSTEVENT_AM audioEvent;

    public Transform player;

    public GameObject feedbackDetction;

    public List<VisualEffect> allVFX;

    // Start is called before the first frame update
    void Start()
    {
        audioEvent = GetComponent<AK_POSTEVENT_AM>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            transform.position = player.position;

        if(allVFX.Count > 0)
        {
            foreach(VisualEffect fx in allVFX)
            {
                fx.SetVector3("PlayerPos", transform.position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Detectable"))
        {
            Instantiate(feedbackDetction, other.transform.position, Quaternion.identity);

            other.GetComponentInChildren<VisualEffect>().enabled = true;

            allVFX.Add(other.GetComponentInChildren<VisualEffect>());

            audioEvent.PostEvent();
        } 
    }
}
