using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_AnimTerminal_LDOV : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!animator.GetComponent<TestTrigger>().isUse)
            {
                animator.SetBool("IsClose", false);
                animator.SetBool("IsOpen", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("IsOpen", false);
            animator.SetBool("IsClose", true);
        }
    }

}
