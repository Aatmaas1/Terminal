using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[ExecuteInEditMode]
public class pos : MonoBehaviour
{

    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mat != null)
        {
            mat.SetVector("_Pos", transform.position);
        }
    }
}
