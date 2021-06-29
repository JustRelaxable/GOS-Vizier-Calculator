using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VizierResearchEfficiency : MonoBehaviour
{
    public Text vizierName;
    public Text vizierResearchEfficiency;
    public Vizier thisVizier;

    void Start()
    {
        vizierName.text = thisVizier.name;
        vizierResearchEfficiency.text = thisVizier.CalculateResearchEfficiency().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
