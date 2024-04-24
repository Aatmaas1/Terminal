using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_TestMemoire_HC : MonoBehaviour
{
    public int index;
    public bool mode;
    // Start is called before the first frame update
    void Start()
    {
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Save changed");
            sc_DataManager.instance.SaveObject(index, mode);
        }
    }
}
