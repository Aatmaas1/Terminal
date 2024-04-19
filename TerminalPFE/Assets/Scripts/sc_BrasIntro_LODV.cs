using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class sc_BrasIntro_LODV : MonoBehaviour
{

    public GameObject character;

    public Transform socket;

    public CharacterController controller;

    public Animator animator;

    bool isTransportingChara;

    Vector3 rota = new Vector3(0, 180, 0);

    private void Start()
    {
        controller.enabled = false;
        animator.enabled = false;
        isTransportingChara = true;
    }

    private void Update()
    {
        if (isTransportingChara)
        {
            character.transform.rotation = Quaternion.Euler(rota);
            character.transform.position = socket.position;
        }
    }

    //à la fin de l'annim, permet de lacher l'android
    public void PosePerso()
    {
        controller.enabled = true;
        animator.enabled = true;
        isTransportingChara = false;
        //réactiver les mouvements
    }

}
