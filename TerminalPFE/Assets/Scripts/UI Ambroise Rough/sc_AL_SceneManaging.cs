using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_AL_SceneManaging : MonoBehaviour
{
    public void restartReel()
    {
        SceneManager.LoadScene("LevelDesignReel");
    }
}
