using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class sc_ObjetScan_HC : MonoBehaviour
{
    public sc_SO_Memoire_HC ObjetRef;

    VisualEffect Vfx;
    float color = 0;
    bool isBlue;

    private void Start()
    {
        Vfx = GetComponent<VisualEffect>();
    }
    private void FixedUpdate()
    {
        if(isBlue && color < 1)
        {
            color += 0.05f;
        }
        if (!isBlue && color > 0)
        {
            color -= 0.05f;
        }
        Vfx.SetFloat("ColorChanger", color);
    }
    public void DevientBleu()
    {
        isBlue = true;
    }
    
    public void DevientBlanc()
    {
        isBlue = false;
    }
}
