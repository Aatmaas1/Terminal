using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Collection de fonctions qui gèrent les transitions entre les scènes
/// </summary>
public class sc_SceneManager_HC : MonoBehaviour
{
    public static sc_SceneManager_HC Instance;

    AsyncOperation asyncLoad;
    bool bLoadDone = true;
    bool isReadyToGo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void ChargeScene(string nom)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nom);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void PrepScene(string nom)
    {
        if (bLoadDone)
        {
            bLoadDone = false;
            isReadyToGo = false;
            StartCoroutine(LoadAsyncScene(nom));
        }
    }

    IEnumerator LoadAsyncScene(string nom)
    {
        asyncLoad = SceneManager.LoadSceneAsync(nom, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        //wait until the asynchronous scene fully loads
        while (asyncLoad.progress < 0.9f)
        {
            //scene has loaded as much as possible,
            // the last 10% can't be multi-threaded
            yield return null;
        }
        bLoadDone = asyncLoad.isDone;
        while (!isReadyToGo)
        {
            yield return null;
        }
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        asyncLoad.allowSceneActivation = true;
    }

    public void IsReadyToLoad()
    {
        isReadyToGo = true;
    }
}
