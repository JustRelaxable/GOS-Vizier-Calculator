using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VizierListManager : MonoBehaviour
{
    public Text powerRaise;
    public Text efficienyRate;
    public Dropdown vizierDropdown;

    void Start()
    {
        vizierDropdown.ClearOptions();
        AddViziersToTheDropdown();
        LoadVizier();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddViziersToTheDropdown()
    {
        List<string> vizierNames = new List<string>();
        foreach (var vizier in DataManager.viziers)
        {
            vizierNames.Add(vizier.name);
        }

        vizierDropdown.AddOptions(vizierNames);
    }

    public void LoadVizier()
    {
        Vizier selectedVizier = DataManager.viziers.Find(y => y.name == vizierDropdown.options[vizierDropdown.value].text);
        powerRaise.text = selectedVizier.CalculateOverallPowerRaiseAtLevelUp().ToString();
        efficienyRate.text = selectedVizier.CalculateRateOfEfficiency().ToString();
    }
}
