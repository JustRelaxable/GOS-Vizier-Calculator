using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowthCalculationVizierPanel : MonoBehaviour
{
    public Text vizerLevel;
    public Text vizierName;
    public Vizier thisVizier;


    void Start()
    {
        vizerLevel.text = thisVizier.vizierLevel.ToString();
        vizierName.text = thisVizier.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
