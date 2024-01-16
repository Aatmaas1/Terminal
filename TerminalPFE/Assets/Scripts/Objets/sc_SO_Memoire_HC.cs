using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "soMemoire", menuName = "ScriptableObjects")]
public class sc_SO_Memoire_HC : ScriptableObject
{
    public string nom;
    [TextArea]
    public string description;
    public GameObject modele3D;
}
