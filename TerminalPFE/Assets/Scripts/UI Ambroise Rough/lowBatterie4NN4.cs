using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowBatterie4NN4 : MonoBehaviour
{
    public GameObject BatterieLowEffect;



        private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            BatterieLowEffect.SetActive(true);
        }
    }
}
