using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_LineSimu_HC : MonoBehaviour
{
    public Transform start, end;
    LineRenderer connect;

    void Start()
    {
        connect = GetComponent<LineRenderer>();
    }


    void Update()
    {
        connect.SetPositions(new Vector3[]{ start.position, end.position});
        connect.widthMultiplier = ((0.25f - Vector3.Distance(start.position, end.position))/0.3f);
    }
}
