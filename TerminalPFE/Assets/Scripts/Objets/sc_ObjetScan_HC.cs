using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class sc_ObjetScan_HC : MonoBehaviour, IDataManager
{
    public sc_SO_Memoire_HC ObjetRef;

    VisualEffect Vfx;
    float color = 0;
    bool isBlue;
    bool isScanned = false;

    private void Start()
    {
        Vfx = GetComponent<VisualEffect>();
    }
    private void FixedUpdate()
    {
        if (isScanned && Vfx.isActiveAndEnabled)
        {
            Vfx.enabled = false;
        }


        if(isBlue && color < 1)
        {
            color += 0.05f;
        }
        if (!isBlue && color > 0)
        {
            color -= 0.05f;
        }
        Vfx.SetFloat("ColorChanger", color);
    }
    public void DevientBleu()
    {
        isBlue = true;
    }
    
    public void DevientBlanc()
    {
        isBlue = false;
    }

    public void Used()
    {
        if (isBlue && !isScanned)
        {
            isScanned = true;
            sc_DataManager.instance.SaveObject(ObjetRef.Index, true);
            sc_PlayerManager_HC.Instance.transform.GetChild(9).GetComponent<VisualEffect>().SendEvent("OnScan");
            sc_ScreenShake.instance.OnInteractPlayerLight();
            StartCoroutine(FreezePlayer());
            sc_PlayerManager_HC.Instance.LookA(transform);
        }
    }

    IEnumerator FreezePlayer()
    {
        sc_PlayerManager_HC.Instance.SetInputMode("Nothing");
        yield return new WaitForSeconds(2.3f);
        sc_PlayerManager_HC.Instance.SetInputMode("Player");
        sc_UIPauseManager.Instance.TestPause();
        sc_UIPauseManager.Instance.LoadInventory();
    }

    public void LoadData(GeneralData data)
    {
        if(data.ItemsCollected[ObjetRef.Index] == true)
        {
            isScanned = true;
        }
    }

    public void SaveData(ref GeneralData data)
    {
        
    }
}
