using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_ScreenShake : MonoBehaviour
{
    //le singletone
    public static sc_ScreenShake instance;

    private  Animator animator;

    // Start is called before the first frame update
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

    public void ScreenBaseQuick()
    {
        animator.SetTrigger("ScreenBaseQuick");
        Debug.Log("ici");
    }

    public void ScreenBaseLong()
    {
        animator.SetTrigger("ScreenBaseLong");
    }

    public void ScreenHardLong()
    {
        animator.SetTrigger("ScreenHardLong");
    }

    public void FovBase()
    {
        animator.SetTrigger("FovBase");
    }

    public void FovBatterie()
    {
        animator.SetTrigger("FovBatterie");
    }
}
