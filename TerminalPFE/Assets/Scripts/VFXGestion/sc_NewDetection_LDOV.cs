using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class sc_NewDetection_LDOV : MonoBehaviour
{
    private AK_POSTEVENT_AM audioEvent;

    private Material _mat;

    [ColorUsage(true, true)]
    public Color colorBase;
    [ColorUsage(true, true)]
    public Color colorBright;

    public float ringSpeed = 1;
    public AnimationCurve ringCurve;

    public Transform player;

    public List<VisualEffect> allVFX;

    // Start is called before the first frame update
    void Start()
    {
        _mat = GetComponent<MeshRenderer>().material;
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

            StartCoroutine(FeedbackMat(other.transform.position));

            other.GetComponentInChildren<VisualEffect>().enabled = true;

            allVFX.Add(other.GetComponentInChildren<VisualEffect>());

            audioEvent.PostEvent();
        } 
    }

    IEnumerator FeedbackMat(Vector3 pos)
    {

        float lerper = 0;

        _mat.SetVector("_Pos", pos);

        float circleSize = 0;

        float circleDiff = 0.9f;

        Color lerperColor;

        while (lerper < 1)
        {
            circleSize = Mathf.Lerp(0, 5f, ringCurve.Evaluate(lerper));
            _mat.SetFloat("_CircleSize", circleSize);

            circleDiff = Mathf.Lerp(0.9f, 0, ringCurve.Evaluate(lerper));
            _mat.SetFloat("_sizeDiff", circleDiff);

            lerper += Time.deltaTime * ringSpeed;

            if (lerper < 0.5f)
            {
                lerperColor = Color.Lerp(colorBase, colorBright, lerper * 2);
                _mat.SetColor("_Color", lerperColor);
            }
            if (lerper >= 0.5f)
            {
                lerperColor = Color.Lerp(colorBright, colorBase, (lerper-0.5f) * 2);
                _mat.SetColor("_Color", lerperColor);
            }


            yield return null;

        }

        //print(circleSize + " & " + circleDiff);

    }
}
