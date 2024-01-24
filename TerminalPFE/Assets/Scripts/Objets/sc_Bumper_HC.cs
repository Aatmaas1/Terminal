using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class sc_Bumper_HC : MonoBehaviour
{
    public Vector3 Direction;
    public float cd;

    bool _isGood = true;

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && _isGood)
        {
            GetComponent<Animator>().Play("Bump");
            collision.transform.parent.GetComponent<ThirdPersonController>().GetBumped(Direction);
            _isGood = false;
            //sc_ScreenShake.instance.ScreenBaseQuick();
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            StartCoroutine(Cd());
        }
    }

    IEnumerator Cd()
    {
        yield return new WaitForSeconds(cd);
        _isGood = true;
    }
}
