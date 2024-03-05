using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class sc_PlayerManager_HC : MonoBehaviour, IDataManager
{
    public ParticleSystem OnJumping;

    public static sc_PlayerManager_HC Instance;
    public int IndexTerminal = -1;

    public float dureeAnimRespawn;

    PlayerInput pInput;

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
        pInput = GetComponent<PlayerInput>();
        pInput.ActivateInput();
    }

    public void LoadData(GeneralData data)
    {
        IndexTerminal = data.indexterminal;
        if (IndexTerminal >= 0)
        {
            pInput = GetComponent<PlayerInput>();
            pInput.ActivateInput();
            Respawn();
            SetInputMode("Nothing");
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                GetComponent<Animator>().Play("AnimSortieTerminalReel");
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                Camera.main.gameObject.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = 0f;
                GetComponent<Animator>().Play("AnimSortieTerminalSimu");
            }
        }
        else
        {
            if (data.LastPos != Vector3.zero)
            {
                GetComponent<CharacterController>().enabled = false;
                transform.position = data.LastPos;
                transform.rotation = data.LastRot;
            }
        }
        GetComponent<CharacterController>().enabled = true;
    }

    public void SaveData(ref GeneralData data)
    {
        data.LastPos = transform.position;
        data.LastRot = transform.rotation;
        data.indexterminal = IndexTerminal;
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            data.lastSceneLoaded = SceneManager.GetActiveScene().buildIndex;
        }
    }

    #region Controles
    public void OnClick()
    {
        IEnumerable<I_Interactible> datapersistenceobjects = FindObjectsOfType<MonoBehaviour>().OfType<I_Interactible>();
        foreach (I_Interactible interf in datapersistenceobjects)
        {
            interf.PressedInteract();
        }
    }

    public void OnJump()
    {
        if (GetComponent<StarterAssets.ThirdPersonController>().Grounded)
        {
            OnJumping.GetComponent<ParticleSystem>().Play();
            sc_ScreenShake.instance.FovBase();
        }
    }

    public void OnInventaire()
    {
        sc_UIPauseManager.Instance.TestPause();
        sc_UIPauseManager.Instance.LoadInventory();
    }

    /// <summary>
    /// A choisir entre Player, UI et Nothing
    /// </summary>
    /// <param name="mode"></param>
    public void SetInputMode(string mode)
    {
        pInput.currentActionMap.Disable();
        pInput.SwitchCurrentActionMap(mode);
        pInput.currentActionMap.Enable();
    }
    #endregion

    #region GestionCutscenes
    public void MakeCamLookAt(Transform obj)
    {
        StartCoroutine(TurnCam(obj));
    }
    IEnumerator TurnCam(Transform obj)
    {
        Transform chi = transform.GetChild(0);
        Quaternion oldrot = chi.rotation;

        Vector3 direction = (obj.position - chi.position).normalized;
        float speed = Vector3.Angle(transform.GetChild(0).forward, direction)/60f;

        for (int i = 1; i <= 60; i++)
        {
            chi.rotation = Quaternion.RotateTowards(chi.rotation, Quaternion.LookRotation(direction, Vector3.up), speed*2);
            chi.eulerAngles = Vector3.Scale(chi.rotation.eulerAngles, new Vector3(1, 1, 0));
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 1; i <= 120; i++)
        {
            transform.GetChild(0).rotation = Quaternion.RotateTowards(transform.GetChild(0).rotation, oldrot, speed);
            chi.eulerAngles = Vector3.Scale(chi.rotation.eulerAngles, new Vector3(1, 1, 0));
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void TurnPlayerToward(Transform cible)
    {
        StartCoroutine(TurnPlayer(cible));
    }
    IEnumerator TurnPlayer(Transform obj)
    {
        Quaternion oldrot = transform.GetChild(0).rotation;

        for (int i = 1; i <= 25; i++)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(obj.position.x, 0, obj.position.z)
                - new Vector3(transform.position.x, 0, transform.position.z), Vector3.up), 10f);
            yield return new WaitForSeconds(0.01f);
            transform.GetChild(0).rotation = oldrot;
        }
    }

    public void MoveToTerminal(Transform term)
    {
        StartCoroutine(MovePlayer(term));
    }
    IEnumerator MovePlayer(Transform obj)
    {
        Vector3 dest = (-new Vector3(obj.position.x, 0, obj.position.z) + new Vector3(transform.position.x, 0, transform.position.z)).normalized
            * 1.1f + new Vector3(obj.position.x, 0, obj.position.z);
        Debug.DrawLine(dest, dest + Vector3.up, Color.red, 5f);
        while (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), dest) > 0.05f)
        {
            transform.Translate(Vector3.Normalize(dest - new Vector3(transform.position.x, 0, transform.position.z)) * 0.05f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void CameraScan(GameObject cible)
    {
        StartCoroutine(CutsceneScan(cible));
    }
    IEnumerator CutsceneScan(GameObject cible)
    {
        Quaternion oldrot = transform.GetChild(0).rotation;


        float maxspeed = Vector3.Angle(transform.GetChild(0).forward, Vector3.Scale(cible.transform.position, new Vector3(1, 1, 0)) -
            Vector3.Scale(transform.GetChild(0).position, new Vector3(1, 1, 0))) / 70f;
        for (int i = 1; i <= 150; i++)
        {
            transform.GetChild(0).rotation = Quaternion.RotateTowards(transform.GetChild(0).rotation,
                Quaternion.LookRotation(Vector3.Scale(cible.transform.position, new Vector3(1, 1, 0)) -
                Vector3.Scale(transform.GetChild(0).position, new Vector3(1, 1, 0)), Vector3.up), maxspeed);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.7f);
        for (int i = 1; i <= 100; i++)
        {
            transform.GetChild(0).Rotate(new Vector3(-45 / 100f, 0, 0));
            yield return new WaitForSeconds(0.01f);
        }

        transform.GetChild(0).rotation = oldrot;
    }

    #endregion

    public void Respawn()
    {
        TestTrigger[] terminaux = FindObjectsOfType<TestTrigger>();
        for (int i = 0; i < terminaux.Length; i++)
        {
            if (terminaux[i].index == IndexTerminal)
            {
                GetComponent<CharacterController>().enabled = false;
                transform.position = terminaux[i].playerAvatarSpawn.transform.position;
                transform.rotation = terminaux[i].playerAvatarSpawn.transform.rotation;
                GetComponent<StarterAssets.ThirdPersonController>().ResetCam(new Vector2(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y));
                transform.GetChild(0).rotation = transform.rotation;
                GetComponent<CharacterController>().enabled = true;
            }
        }
    }

    public void LanceAnimRespawn()
    {
        StartCoroutine(AnimRespawn());
    }

    IEnumerator AnimRespawn()
    {
        SetInputMode("Nothing");
        GetComponent<Animator>().Play("AnimRespawn");
        yield return new WaitForSeconds(dureeAnimRespawn);
        SetInputMode("Player");

    }

    public void EndAnim()
    {
        StartCoroutine(DelayFixCam());
    }

    IEnumerator DelayFixCam()
    {
        yield return new WaitForEndOfFrame();
        Camera.main.gameObject.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = 0.5f;
    }
}
