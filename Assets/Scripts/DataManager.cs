using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataManager : MonoBehaviour
{

    public static string DATA_PATH = "/Viziers.dat";
    public static DataManager dataManager;
    public static VizierList viziers = new VizierList();

    private void Awake()
    {
        if(dataManager == null)
        {
            dataManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        if (File.Exists(Application.persistentDataPath + DATA_PATH))
        {
            FileStream vizierFile = null;

            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                vizierFile = File.Open(Application.persistentDataPath + DATA_PATH, FileMode.Open);
                viziers = binaryFormatter.Deserialize(vizierFile) as VizierList;
            }
            finally
            {
                if(vizierFile != null)
                {
                    vizierFile.Close();
                }
            }
        }   
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SaveVizier(Vizier vizier)
    {
        FileStream vizierFile = null;
        viziers.Add(vizier);
        try
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            vizierFile = File.Create(Application.persistentDataPath + DATA_PATH);
            binaryFormatter.Serialize(vizierFile,viziers);
        }
        finally
        {
            if (vizierFile != null)
            {
                vizierFile.Close();
            }
        }
    }

    public static void DeleteViziers()
    {
        //FileStream fileToDelete = null;

        try
        {
            //File.Delete(Application.persistentDataPath + DATA_PATH);
            //viziers.Clear();
        }
        finally
        {

        }
    }

    public static void UpdateViziers()
    {
        FileStream vizierFile = null;
        try
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            vizierFile = File.Create(Application.persistentDataPath + DATA_PATH);
            binaryFormatter.Serialize(vizierFile, viziers);
        }
        finally
        {
            if (vizierFile != null)
            {
                vizierFile.Close();
            }
        }
    }
}
