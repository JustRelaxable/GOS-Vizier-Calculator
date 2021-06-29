using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VizierSpawner : MonoBehaviour
{
    public GameObject vizierCardTemplate;
    VizierCardReader vizierCardReaderScript;
    public List<VizierCard> vizierCards;
    public GameObject parent;
    public static VizierSpawner vizierSpawner;
    void Start()
    {
        MakeConfigurations();
        for (int i = 0; i < vizierCards.Count; i++)
        {
            GameObject createdCardTemplate = Instantiate(vizierCardTemplate,parent.transform);
            vizierCardReaderScript = createdCardTemplate.GetComponent<VizierCardReader>();
            vizierCardReaderScript.vizierCard = vizierCards[i];
        }
    }

    public void MakeConfigurations()
    {
        parent = GameObject.FindGameObjectWithTag("VizierCardTable");

        if(vizierSpawner == null)
        {
            vizierSpawner = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }
}
