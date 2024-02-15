using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class sc_Algue : MonoBehaviour
{
    public Material _mat;
    public Transform _playerTransform;

    public float growValue;

    // Start is called before the first frame update
    void Start()
    {
        _mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if( _mat == null )
            _mat = GetComponentInChildren<SkinnedMeshRenderer>().material;

        float distance = Mathf.Clamp(Vector3.Distance(transform.position, _playerTransform.position), 0, 1);

        growValue = (Mathf.Abs(distance));

        _mat.SetFloat("_Grow", growValue);

    }
}
