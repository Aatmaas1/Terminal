using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecteurPorteTuto : MonoBehaviour
{
    public Animator PorteTutoAnimator;
   public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("yo");
            PorteTutoAnimator.SetTrigger("IsOpening");
        }
    }
}
