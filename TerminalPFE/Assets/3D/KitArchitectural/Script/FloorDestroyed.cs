using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroyed : MonoBehaviour
{

    public  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
