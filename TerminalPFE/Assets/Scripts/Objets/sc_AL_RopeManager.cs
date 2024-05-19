using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class sc_AL_RopeManager : MonoBehaviour
{
    //public LineRenderer myLineRenderer;
    public VisualEffect link01;
    public GameObject leadTarget;
    public GameObject followTarget;
    //public LineRenderer mysecondLineRenderer;
    public VisualEffect link02;
    public GameObject secondleadTarget;
    public GameObject secondfollowTarget;

    // Start is called before the first frame update
    void Start()
    {
       //myLineRenderer.positionCount = 2;
        //mysecondLineRenderer.positionCount = 2;

    }

    // Update is called once per frame
    void Update()
    {
        /*
        myLineRenderer.SetPosition(0, new Vector3(leadTarget.transform.position.x, leadTarget.transform.position.y + 1, leadTarget.transform.position.z));
        myLineRenderer.SetPosition(1, new Vector3(followTarget.transform.position.x + 2, followTarget.transform.position.y + 0.9f, followTarget.transform.position.z));
        mysecondLineRenderer.SetPosition(0, new Vector3(secondleadTarget.transform.position.x +3, secondleadTarget.transform.position.y + 0.9f, secondleadTarget.transform.position.z));
        mysecondLineRenderer.SetPosition(1, new Vector3(secondfollowTarget.transform.position.x + 4, secondfollowTarget.transform.position.y + 0.9f, secondfollowTarget.transform.position.z));
        */

        #region cable planeur 01 à 4NN4
        link01.SetVector3("Pos01", leadTarget.transform.position);

        Vector3 pos02 = Vector3.Lerp(leadTarget.transform.position, followTarget.transform.position, 0.33f);
        link01.SetVector3("Pos02", pos02);

        Vector3 pos03 = Vector3.Lerp(leadTarget.transform.position, followTarget.transform.position, 0.66f);
        link01.SetVector3("Pos03", pos03);

        link01.SetVector3("Pos04", followTarget.transform.position);
        #endregion

        #region cable grand planeur à petit
        link02.SetVector3("Pos01", secondleadTarget.transform.position);

        Vector3 ndpos02 = Vector3.Lerp(secondleadTarget.transform.position, secondfollowTarget.transform.position, 0.33f);
        link02.SetVector3("Pos02", ndpos02);

        Vector3 rdpos03 = Vector3.Lerp(secondleadTarget.transform.position, secondfollowTarget.transform.position, 0.66f);
        link02.SetVector3("Pos03", rdpos03);

        link02.SetVector3("Pos04", secondfollowTarget.transform.position);
        #endregion
    }
}
