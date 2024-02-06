using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_animationTerminalSimu : MonoBehaviour
{
    public static sc_animationTerminalSimu instance;

    private Animator animator;
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void lePersoEntreDansSimu()
    {
       // animator.SetTrigger("EntreSimu");

    }

    public void lePersoSortDeSimu()
    {
        animator.SetTrigger("LeftSimu");

    }
}
