using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(sc_Bumper_HC))]
public class sc_BumperEditor_HC : Editor
{
    public void OnSceneGUI()
    {
        var t = target as sc_Bumper_HC;
        Vector3 dir = t.Direction;

        Color coolor = new Color(255, 0, 0, 255);
        Handles.color = coolor;
        t.Direction = Handles.PositionHandle(dir + t.transform.position, Quaternion.identity) - t.transform.position;

        GUI.color = coolor;
        Handles.Label(dir + t.transform.position, dir.x.ToString("0.00") + ";" + dir.y.ToString("0.00") + ";" + dir.z.ToString("0.00"));

        Handles.DrawLine(t.transform.position, dir + t.transform.position);
    }
}
