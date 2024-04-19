using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class sc_BrasIntro_LODV : MonoBehaviour
{

    public GameObject character;

    public Transform socket;

    public CharacterController controller;

    bool isTransportingChara;

    private void Start()
    {
        controller.enabled = false;
        isTransportingChara = true;
    }

    private void Update()
    {
        if (isTransportingChara)
        {
            character.transform.position = socket.position;
        }
    }

    //à la fin de l'annim, permet de lacher l'android
    public void PosePerso()
    {
        isTransportingChara = false;
        controller.enabled = true;
        //réactiver les mouvements
    }

}
