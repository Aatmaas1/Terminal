using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerTargetPos : MonoBehaviour
{
    //je suis un script presque vide dont l'utilité est de servir de cible pour que Audio Yuumi s'attache sur mon transform :)

    //Mon autre utilité est de permettre à Audio Yuumi de se détacher de moi pour me laisser crever seul quand une nouvelle scène est load, yihiiii ^_^

    public void AudioYuumiDetach()
    {
        AudioListenerDontDestroyOnLoad.instance.AudioYuumi();
    }
}
