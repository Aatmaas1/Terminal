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
    }
}
