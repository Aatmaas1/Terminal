using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class AK_CRACKLING_FIX : MonoBehaviour
{
    public void RegisterAllObj()
    {
        //en espérant qu'il n'y en aura pas besoin...
    }

    public void UnregisterAllObj()  
    {
        AkSoundEngine.UnregisterAllGameObj();
        AudioListenerDontDestroyOnLoad.instance.RegisterYuumi();
    }
}
