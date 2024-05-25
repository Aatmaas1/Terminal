using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_OTE_AM : MonoBehaviour
{
    bool isPlaying = false;

    public AK_POST_PAS_AM postPas;

    private void Start()
    {
        postPas = GetComponent<AK_POST_PAS_AM>();
    }

    private void OnCollisionEnter(UnityEngine.Collision in_other)
    {
        if (in_other != null && in_other.collider.CompareTag("Walkable") && isPlaying == false)
        {
            postPas.PostSol();
            StartCoroutine(ResetIsPlaying());
        }

        if (in_other != null && in_other.collider.CompareTag("WalkableSand") && isPlaying == false)
        {
            postPas.PostSable();
            StartCoroutine(ResetIsPlaying());
        }

        if (in_other != null && in_other.collider.CompareTag("WalkableGrille") && isPlaying == false)
        {
            postPas.PostSol();
            StartCoroutine(ResetIsPlaying());
        }


    }

    private void OnTriggerEnter(UnityEngine.Collider in_other)
    {
        if (in_other != null && in_other.CompareTag("Walkable") && isPlaying == false)
        {
            postPas.PostSol();
            StartCoroutine(ResetIsPlaying());
        }

        if (in_other != null && in_other.CompareTag("WalkableSand") && isPlaying == false)
        {
            postPas.PostSable();
            StartCoroutine(ResetIsPlaying());
        }

        if (in_other != null && in_other.CompareTag("WalkableGrille") && isPlaying == false)
        {
            postPas.PostSol();
            StartCoroutine(ResetIsPlaying());
        }
    }



    IEnumerator ResetIsPlaying()
    {
        isPlaying = true;
        yield return new WaitForSecondsRealtime(0.5f);
        isPlaying = false;
    }
}
