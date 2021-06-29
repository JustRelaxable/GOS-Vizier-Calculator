using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

public class MyVizierList : MonoBehaviour
{
    public static List<VizierCardDataContainer> myViziers = new List<VizierCardDataContainer>();
    public static string DATA_PATH = "/NewViziers.dat";

    private void Awake()
    {
        GetViziers();
    }

    static public void AddVizier(VizierCard vizier) 
    {
        if(!myViziers.Any(v => v.vizierName == vizier.vizierName))
        {
            VizierCardDataContainer newVizier = new VizierCardDataContainer(vizier.vizierName, vizier.vizierLevel, vizier.talents,vizier.vizierIndex);
            myViziers.Add(newVizier);
            RefreshVizierList();
        }
    }

    public static void SaveVizier()
    {
        FileStream vizierFile = null;
        try
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            vizierFile = File.Create(Application.persistentDataPath + DATA_PATH);
            binaryFormatter.Serialize(vizierFile, myViziers);
        }
        finally
        {
            if (vizierFile != null)
            {
                vizierFile.Close();
            }
        }
    }

    public static void GetViziers()
    {
        if (File.Exists(Application.persistentDataPath + DATA_PATH))
        {
            FileStream vizierFile = null;

            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                vizierFile = File.Open(Application.persistentDataPath + DATA_PATH, FileMode.Open);
                myViziers = binaryFormatter.Deserialize(vizierFile) as List<VizierCardDataContainer>;
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

    public static void DeleteViziers(VizierCard vizier)
    {
        for (int i = 0; i < myViziers.Count; i++)
        {
            if (vizier.vizierName == myViziers[i].vizierName)
            {
                myViziers.Remove(myViziers[i]);
                RefreshVizierList();
            }
        }
    }

    static void RefreshVizierList()
    {
        SaveVizier();
        GetViziers();
    }
}
