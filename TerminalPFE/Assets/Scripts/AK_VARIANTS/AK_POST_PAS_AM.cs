using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_POST_PAS_AM : MonoBehaviour
{
    public AK.Wwise.Event PasSol;

    public AK.Wwise.Event PasGrille;

    public AK.Wwise.Event PasSable;

    public void PostSol()
    {
        PasSol.Post(gameObject);
    }

    public void PostGrille()
    {
        PasGrille.Post(gameObject);
    }

    public void PostSable()
    {
        PasSable.Post(gameObject);
    }

    public void Update()
    {
        AkSoundEngine.SetObjectPosition(gameObject, gameObject.transform);
    }
}
