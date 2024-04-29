using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[ExecuteInEditMode]
public class sc_CableTool_LDOV : MonoBehaviour
{

    public LineRenderer cable;

    [Header("Les courbes qui permettent de modifier l'aspect du cable")]
    [Header("t = 0 -> startPos; t = 1 -> endPos")]
    [Tooltip("Modifie selon l'axe X")]
    public AnimationCurve curveX;
    [Tooltip("Modifie selon l'axe Y")]
    public AnimationCurve curveY;
    [Tooltip("Modifie selon l'axe Z")]
    public AnimationCurve curveZ;

    [Space]

    [Tooltip("Pour modifier l'épaisseur du cable")]
    [Range(0f, 1f)]
    public float cableSize;

    [Space]

    [Tooltip("La position De départ")]
    public Transform startPos;
    [Tooltip("La position De Fin")]
    public Transform endPos;

    [Space]

    [Tooltip("Permet de changer le material du cable")]
    public Material cableMat;
    [Header("Agit comme le tiling & offset")]
    public Vector2 textureScale = new Vector2(1,1);

    [Space]

    [Header("PLus de vertex -> meilleure correspondance avec la courbe")]
    [Range(2, 50)]
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

                for (float i = 1; i < vertexNomber -1 ; i+=1)
                {
                    float lerper = (i / (vertexNomber-1));
                    Vector3 pointPos = Vector3.Lerp(startPos.position, endPos.position, lerper);

                    float modifX = pointPos.x + (curveX.Evaluate(i/vertexNomber)-1);
                    float modifY = pointPos.y + (curveY.Evaluate(i/vertexNomber)-1);
                    float modifZ = pointPos.z + (curveZ.Evaluate(i/vertexNomber)-1);

                    Vector3 modifPos = new Vector3(modifX, modifY, modifZ);

                    int index = Mathf.FloorToInt(i);
                    cable.SetPosition(index, modifPos);
                }

                cable.SetPosition(0, startPos.position);
                cable.SetPosition(vertexNomber -1, endPos.position);

            //la taille
            AnimationCurve sizeCurve = new AnimationCurve();
            sizeCurve.AddKey(0, cableSize);
            sizeCurve.AddKey(1, cableSize);
            cable.widthCurve = sizeCurve;

            //le material
            if(cableMat!= null)
            {
                cable.material = cableMat;
                cable.textureScale = textureScale;
            }

        }
    }
#endif
}
