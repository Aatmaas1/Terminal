using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_DetectionFeedback : MonoBehaviour
{

    public AnimationCurve curve;

    public Vector3 goalSize;

    private Material _mat;

    // Start is called before the first frame update
    void Start()
    {
        _mat = GetComponent<MeshRenderer>().material;

        StartCoroutine(Buble());
    }

    IEnumerator Buble()
    {
        float lerper = 0;

        float offsetChanger = 0;

        while(lerper < 1)
        {
            offsetChanger = Mathf.Lerp(0, 0.5f, curve.Evaluate(lerper));
            transform.localScale = Vector3.Lerp(Vector3.zero, goalSize, curve.Evaluate(lerper));
            _mat.SetFloat("_Offset",offsetChanger);
            lerper += Time.deltaTime;
            yield return null;

        }

        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);

    }
}
