using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AK.Wwise;
using Unity.VisualScripting;

public class AudioListenerDontDestroyOnLoad : MonoBehaviour
{
    public static AudioListenerDontDestroyOnLoad instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        AkSoundEngine.SetRTPCValue("BatterieFaible", 0);

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            transform.position = FindAnyObjectByType<AudioListenerTargetPos>().transform.GetChild(2).transform.GetChild(0).transform.GetChild(2)
                                                                            .transform.GetChild(0).transform.GetChild(0).transform.GetChild(1)
                                                                            .transform.GetChild(0).transform.position;          

            transform.rotation = FindAnyObjectByType<AudioListenerTargetPos>().transform.GetChild(2).transform.GetChild(0).transform.GetChild(2)
                                                                            .transform.GetChild(0).transform.GetChild(0).transform.GetChild(1)
                                                                            .transform.GetChild(0).transform.rotation;

            transform.parent = FindAnyObjectByType<AudioListenerTargetPos>().transform.GetChild(2).transform.GetChild(0).transform.GetChild(2)
                                                                            .transform.GetChild(0).transform.GetChild(0).transform.GetChild(1)
                                                                            .transform.GetChild(0).transform;
        }
        else
        {
            transform.position = FindAnyObjectByType<AudioListenerTargetPos>().transform.position;
            transform.rotation = FindAnyObjectByType<AudioListenerTargetPos>().transform.rotation;
            transform.parent = FindAnyObjectByType<AudioListenerTargetPos>().transform;
        }
    }

    public void AudioYuumi()
    {
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }

    public void RegisterYuumi()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
    }

    public AK.Wwise.Event simu1;
    public AK.Wwise.Event simu2;
    public AK.Wwise.Event simu3;
    public AK.Wwise.Event battementsCoeur;
    public AK.Wwise.Event battementsCoeurStop;
    public bool simu1AlreadyLoaded = false;
    public bool earthQuakeSpecial = false;


    public AK.Wwise.Event code;
    public AK.Wwise.Event stopCode;
    public void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            transform.position = FindAnyObjectByType<AudioListenerTargetPos>().transform.position;
            transform.rotation = FindAnyObjectByType<AudioListenerTargetPos>().transform.rotation;
            transform.parent = FindAnyObjectByType<AudioListenerTargetPos>().transform.GetChild(2).transform.GetChild(0).transform.GetChild(2)
                                                                            .transform.GetChild(0).transform.GetChild(0).transform.GetChild(1)
                                                                            .transform.GetChild(0).transform;
        }
        else
        {
            transform.position = FindAnyObjectByType<AudioListenerTargetPos>().transform.position;
            transform.rotation = FindAnyObjectByType<AudioListenerTargetPos>().transform.rotation;
            transform.parent = FindAnyObjectByType<AudioListenerTargetPos>().transform;

        }

        if (level == 2 && simu1AlreadyLoaded && !earthQuakeSpecial)
        {           
            simu2.Post(gameObject);
        }

        if (level == 2 && !simu1AlreadyLoaded && !earthQuakeSpecial)
        {
            simu1.Post(gameObject);
            simu1AlreadyLoaded = true;
        }

        if(level == 2 && earthQuakeSpecial == true && simu1AlreadyLoaded)
        {
            simu3.Post(gameObject);
            battementsCoeurStop.Post(gameObject);
            earthQuakeSpecial = false;
        }

    }

    public void AfterEarthQuake()
    {
        battementsCoeur.Post(gameObject);
        earthQuakeSpecial = true;

        AkSoundEngine.SetRTPCValue("VentAfterEarthQuake", 100f);
    }

    public void Code()
    {
        code.Post(gameObject);
    }

    public void StopCode()
    {
        stopCode.Post(gameObject);
    }
}
