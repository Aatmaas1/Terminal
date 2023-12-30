using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataManager
{
    void LoadData(GeneralData data);

    void SaveData(ref GeneralData data);
}
