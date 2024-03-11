using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class sc_NewDetection_LDOV : MonoBehaviour
{

    private Material _mat;

    public float ringSpeed = 1;

    public Transform player;

    public List<VisualEffect> allVFX;

    // Start is called before the first frame update
    void Start()
    {
        _mat = GetComponent<MeshRenderer>().material;
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
                fx.SetVector3("PlayerPos", player.position);
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
        } 
    }

    IEnumerator FeedbackMat(Vector3 pos)
    {

        float lerper = 0;

        _mat.SetVector("_Pos", pos);

        float circleSize = 0;

        float circleDiff = 0.9f;

        while (lerper < 1)
        {
            circleSize = Mathf.Lerp(circleSize, 5f, lerper);
            _mat.SetFloat("_CircleSize", circleSize);

            circleDiff = Mathf.Lerp(circleDiff, 0, lerper);
            _mat.SetFloat("_sizeDiff", circleDiff);

            lerper += Time.deltaTime * ringSpeed;


            yield return null;

        }

        print(circleSize + " & " + circleDiff);

    }
}
