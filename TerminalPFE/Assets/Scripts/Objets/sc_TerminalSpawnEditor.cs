using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR



[CustomEditor(typeof(TestTrigger))]
public class sc_TerminalSpawnEditor : Editor
{
    public void OnSceneGUI()
    {
        var t = target as TestTrigger;
        Transform dir = t.playerAvatarSpawn.transform;

        Color coolor = new Color(255, 0, 0, 255);
        Handles.color = coolor;

        Handles.DrawLine(dir.position, dir.position + dir.transform.forward);
    }
}
#endif