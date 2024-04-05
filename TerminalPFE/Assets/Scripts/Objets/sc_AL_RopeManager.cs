using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_AL_RopeManager : MonoBehaviour
{
    public LineRenderer myLineRenderer;
    public GameObject leadTarget;
    public GameObject followTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        myLineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        myLineRenderer.SetPosition(0, new Vector3(leadTarget.transform.position.x, leadTarget.transform.position.y + 1, leadTarget.transform.position.z));
        myLineRenderer.SetPosition(1, new Vector3(followTarget.transform.position.x + 2, followTarget.transform.position.y + 1, followTarget.transform.position.z));

    }
}
