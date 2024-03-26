using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_SandPos_LDOV : MonoBehaviour
{

    Material _sandMat;

    public Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        _sandMat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPos != null) 
        _sandMat.SetVector("_Pos", playerPos.position);
    }
}
