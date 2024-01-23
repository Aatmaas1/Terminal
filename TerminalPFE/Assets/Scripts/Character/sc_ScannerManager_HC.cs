using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_ScannerManager_HC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<sc_TargetScan_HC>())
        {
            other.GetComponent<sc_TargetScan_HC>().GetClicked();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<sc_TargetScan_HC>())
        {
            other.GetComponent<sc_TargetScan_HC>().GetLost();
        }
    }
}
