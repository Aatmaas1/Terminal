using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerTargetPos : MonoBehaviour
{
    //je suis un script presque vide dont l'utilit� est de servir de cible pour que Audio Yuumi s'attache sur mon transform :)

    //Mon autre utilit� est de permettre � Audio Yuumi de se d�tacher de moi pour me laisser crever seul quand une nouvelle sc�ne est load, yihiiii ^_^

    public void AudioYuumiDetach()
    {
        AudioListenerDontDestroyOnLoad.instance.AudioYuumi();
    }
}
