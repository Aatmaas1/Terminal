using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_OptionDissableBG : MonoBehaviour
{
    public GameObject BackGround;


    public void active()
    {
        BackGround.SetActive(true);
    }
    public void desactive()
    {
        BackGround.SetActive(false);
    }
}
