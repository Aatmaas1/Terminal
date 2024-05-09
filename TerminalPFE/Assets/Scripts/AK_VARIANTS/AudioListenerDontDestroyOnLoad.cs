using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        transform.parent = FindAnyObjectByType<AudioListenerTargetPos>().transform;
    }

    public void AudioYuumi()
    {
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }

    public void OnLevelWasLoaded(int level)
    {
        transform.position = FindAnyObjectByType<AudioListenerTargetPos>().transform.position;
        transform.rotation = FindAnyObjectByType<AudioListenerTargetPos>().transform.rotation;
        transform.parent = FindAnyObjectByType<AudioListenerTargetPos>().transform;
        transform.localPosition = transform.localPosition + new Vector3(0.054f, 1.65f, 0.041f);
    }
}
