using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class sc_FileHandler_HC
{
    private string DataPath = "";
    private string FileName = "";


    public sc_FileHandler_HC(string dataPath, string fileName)
    {
        DataPath = dataPath;
        FileName = fileName;
    }


    public GeneralData Load()
    {
        //Combine pr que ça marche sur windows, linux et mac (normalement)
        string FullPath = Path.Combine(DataPath, FileName);
        GeneralData loadedData = null;
        if (File.Exists(FullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(FullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }


                //Deserialisation
                loadedData = JsonUtility.FromJson<GeneralData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load file : " + FullPath + "\n" + e);
            }
        }
        return loadedData;
    }


    public void Save(GeneralData data)
    {
        //Combine pr que ça marche sur windows, linux et mac (normalement)
        string FullPath = Path.Combine(DataPath, FileName);


        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FullPath));

            //Serialisation
            string dataToStore = JsonUtility.ToJson(data, true);


            using(FileStream stream = new FileStream(FullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("Error occured when trying to save to file : " + FullPath + "\n" +  e);
        }
    }
}
