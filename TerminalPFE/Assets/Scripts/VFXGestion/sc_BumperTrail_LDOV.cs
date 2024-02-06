using UnityEngine;
using UnityEngine.VFX;

[ExecuteInEditMode]
public class sc_BumperTrail_LDOV : MonoBehaviour
{

    public Transform pos01;
    public Transform pos02;
    public Transform pos03;
    public Transform pos04;

    public VisualEffect bumperVFX;

    // Update is called once per frame
    void Update()
    {

        bumperVFX.SetVector3("Pos01", pos01.position);
        bumperVFX.SetVector3("Pos02", pos02.position);
        bumperVFX.SetVector3("Pos03", pos03.position);
        bumperVFX.SetVector3("Pos04", pos04.position);
    }
}
