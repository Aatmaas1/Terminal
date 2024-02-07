using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_animationTerminalSimu : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    public void lePersoEntreDansSimu()
    {
       // animator.SetTrigger("EntreSimu");

    }

    public void lePersoSortDeSimu()
    {
        Debug.Log("aaa");
        animator.SetTrigger("LeftSimu");

    }
}
