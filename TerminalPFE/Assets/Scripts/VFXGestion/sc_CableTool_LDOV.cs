using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[ExecuteInEditMode]
public class sc_CableTool_LDOV : MonoBehaviour
{

    public LineRenderer cable;
    public AnimationCurve curve;

    [Range(0f, 1f)]
    public float cableSize;

    public Transform startPos;
    public Transform endPos;

    [Range(2, 20)]
    public int vertexNomber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

#if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        if(cable != null)
        {
            //les positions
            cable.SetVertexCount(vertexNomber);

            if (vertexNomber > 2)
            {
                for (float i = 0; i < vertexNomber ; i+=1)
                {
                    float lerper = (i / (vertexNomber-1));
                    Vector3 pointPos = Vector3.Lerp(startPos.position, endPos.position, lerper);

                    float modifY = pointPos.y + (curve.Evaluate(i/vertexNomber)-1);

                    Vector3 modifPos = new Vector3(pointPos.x, modifY, pointPos.z);

                    int index = Mathf.FloorToInt(i);
                    cable.SetPosition(index, modifPos);
                }
            }

            else
            {
                cable.SetPosition(0, startPos.position);
                cable.SetPosition(1, endPos.position);
            }

            //la taille
            AnimationCurve sizeCurve = new AnimationCurve();
            sizeCurve.AddKey(0, cableSize);
            sizeCurve.AddKey(1, cableSize);
            cable.widthCurve = sizeCurve;

        }
    }
#endif
}
