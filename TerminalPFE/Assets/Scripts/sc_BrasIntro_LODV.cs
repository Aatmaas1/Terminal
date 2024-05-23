using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;




public class sc_BrasIntro_LODV : MonoBehaviour
{

    public GameObject character;

    public Transform socket;

    public CharacterController controller;

    public Animator animator;

    bool isTransportingChara;

    public Animator fadeInAnimator;

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
            fadeInAnimator.SetBool("FadeIn", true);
        }
        else
            Destroy(fadeInAnimator.gameObject);
    }

    private void Update()
    {
        if (isTransportingChara /*&& hasAlreadyTransportPlayer == false*/)
        {
            character.transform.rotation = Quaternion.Euler(rota);
            character.transform.position = socket.position;
            //hasAlreadyTransportPlayer = true;

            if (sc_PlayerManager_HC.Instance.isZooming)
                AlreadyZoom();
        }
    }

    public void AlreadyZoom()
    {
        GetComponent<Animator>().SetBool("AlreadyZoom", true);
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
