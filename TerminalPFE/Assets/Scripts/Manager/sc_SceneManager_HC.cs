using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Collection de fonctions qui g�rent les transitions entre les sc�nes
/// </summary>
public class sc_SceneManager_HC : MonoBehaviour
{
    public static sc_SceneManager_HC Instance;

    AsyncOperation asyncLoad;
    bool bLoadDone;
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
        bLoadDone = false;
        isReadyToGo = true;
        StartCoroutine(LoadAsyncScene(nom));
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
            yield return new WaitForEndOfFrame();
        }
        bLoadDone = asyncLoad.isDone;
        while (!isReadyToGo)
        {
            yield return new WaitForEndOfFrame();
        }
        asyncLoad.allowSceneActivation = true;
    }

    public void IsReadyToLoad()
    {
        isReadyToGo = true;
    }
}
