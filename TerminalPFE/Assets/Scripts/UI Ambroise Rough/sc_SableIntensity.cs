using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_SableIntensity : MonoBehaviour
{
    public GameObject TempeteDeSable1;
    public GameObject TempeteDeSable2;

    public void StopSand()
    {
        TempeteDeSable1.SetActive(false);
        TempeteDeSable2.SetActive(false);
    }

    public void RestartSand()
    {
        TempeteDeSable1.SetActive(true);
        TempeteDeSable2.SetActive(true);
    }
}
