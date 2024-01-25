using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_LerpSphere_HC : MonoBehaviour
{
    public Transform target;

    public float ratio;

    Vector3 LastPos;

    private void Start()
    {
        LastPos = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(target.position, LastPos, Mathf.Clamp((ratio - Vector3.Distance(target.position, LastPos) / ratio), 0, 1));
        LastPos = transform.position;
    }
}
