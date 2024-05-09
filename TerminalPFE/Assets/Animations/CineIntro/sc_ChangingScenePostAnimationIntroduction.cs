using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sc_ChangingScenePostAnimationIntroduction : MonoBehaviour
{

    public void ChangeScene()
    {
        AudioListenerDontDestroyOnLoad.instance.AudioYuumi(); //c'est encore moi ^_^ je dois me détacher

        SceneManager.LoadScene("LevelDesignReel");
    }

}
