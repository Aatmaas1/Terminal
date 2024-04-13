using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class Door : MonoBehaviour
{
     Material mats;

    public Transform playerPos;

    public float rad;

    private void Start()
    {
        mats = GetComponent<MeshRenderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        mats.SetVector("_Pos", playerPos.position);
        mats.SetFloat("_Radius", rad);
    }
}
