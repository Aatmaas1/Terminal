using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "soMemoire", menuName = "ScriptableObjectMemoire")]
public class sc_SO_Memoire_HC : ScriptableObject
{
    public int Index;
    public string nom;
    [TextArea]
    public string description, commentaireAndroid;
}
