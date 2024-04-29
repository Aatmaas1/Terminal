using UnityEngine;
using UnityEngine.SceneManagement;




public class sc_BrasIntro_LODV : MonoBehaviour
{

    public GameObject character;

    public Transform socket;

    public CharacterController controller;

    public Animator animator;

    bool isTransportingChara;

    public bool isRealStart;
    // bool hasAlreadyTransportPlayer = false;

    Vector3 rota = new Vector3(0, 180, 0);

    private void Start()
    {
        if (!sc_DataManager.instance.TestIsNewSave())
            isRealStart = false;


        if (isRealStart)
        {
            controller.enabled = false;
            animator.enabled = false;
            isTransportingChara = true;
            isRealStart = false;
        }
    }

    private void Update()
    {
        if (isTransportingChara /*&& hasAlreadyTransportPlayer == false*/)
        {
            character.transform.rotation = Quaternion.Euler(rota);
            character.transform.position = socket.position;
            //hasAlreadyTransportPlayer = true;
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
