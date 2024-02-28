using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.VFX;

public class sc_CameraEffect_HC : MonoBehaviour
{
    VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        sc_SceneManager_HC.Instance.IsReadyToLoad();
        //vp.enabled = false;
    }

    public void PlayVid()
    {
        Camera.main.nearClipPlane = 0.00001f;
        videoPlayer.Play();
        GetComponent<VisualEffect>().enabled = false;
    }

    public void PrepareVideo()
    {
        videoPlayer.Prepare();
    }
}
