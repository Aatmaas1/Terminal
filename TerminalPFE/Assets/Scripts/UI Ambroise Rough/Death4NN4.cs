using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death4NN4 : MonoBehaviour
{
    public Animator PlayerAnimator;

    public GameObject fadeToBlack;
    public GameObject rope4NN4ToPlanner;
    //public GameObject ThirdPersonController;



    [Header("Contrôle des timings")]
    public float timeToStop;
    public float timeToDie;
    public float timeToFade;
    public float timeToLoad;

    public AK_POSTEVENT_AM postEvent;

    private void Start()
    {
        postEvent = GetComponent<AK_POSTEVENT_AM>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WaitAnimDeath());
        }
    }


    IEnumerator WaitAnimDeath()
    {
        PlayerAnimator.GetComponent<Animator>().SetTrigger("SlowWalk");
        StartCoroutine(SlowDown());

        postEvent.PostEvent();

        yield return new WaitForSeconds(timeToStop);

        //PlayerAnimator.GetComponent<Animator>().SetTrigger("StopSlowWalk");

        //En attendant
        PlayerAnimator.GetComponent<Animator>().speed = 0.2f;
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");

        yield return new WaitForSeconds(timeToDie);

        PlayerAnimator.GetComponent<Animator>().speed = 1f;
        sc_ScreenShake.instance.ScreenBaseQuick();
        PlayerAnimator.GetComponent<Animator>().SetTrigger("Death");
        rope4NN4ToPlanner.SetActive(false);

        yield return new WaitForSeconds(timeToFade);

        fadeToBlack.SetActive(true);
        postEvent.PostStopEvent();

        yield return new WaitForSeconds(timeToLoad);
        //sc_PlayerManager_HC.Instance.SetInputMode("Player");
        AkSoundEngine.SetRTPCValue("BatterieFaible", 0f);

        AudioListenerDontDestroyOnLoad.instance.AudioYuumi();
        AkSoundEngine.UnregisterAllGameObj();
        AudioListenerDontDestroyOnLoad.instance.RegisterYuumi();

        SceneManager.LoadScene("Introduction");

    }

    IEnumerator SlowDown()
    {
        for (float i = 0f; i < 200f; i++)
        {
            PlayerAnimator.gameObject.GetComponent<ThirdPersonController>().MoveSpeed = 4 * (1f - (0.75f * i * 0.005f));
            yield return new WaitForSeconds(0.01f);
        }
    }

    public float initialLPF;
    public float timeToFullLPF;

    IEnumerator LPFDeath()
    {
        float time = 0f;

        while(time < 1f)
        {
            AkSoundEngine.SetRTPCValue("BatterieFaible", Mathf.Lerp(initialLPF, 100, time / timeToFullLPF));
            yield return null;
            StopCoroutine(LPFDeath());
        }      
    }
}
