using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EfficiencyCard : MonoBehaviour
{
    public VizierCardDataContainer vizierCardDataContainer;
    public Text vizierName;
    public Text overallEfficiencyText;
    public Text powerEfficiencyText;
    public Text militaryEfficiencyText;
    public Text researchEfficiencyText;
    public Text politicEfficiencyText;
    public Text prestigeEfficiencyText;
    public Image imageOfVizier;
    public LocalizedTextComponent localizedText;
    public static bool adWatched = false;

    private void Awake()
    {

    }

    private void Start()
    {
        SetEfficiencyValues();
    }
    
    public void SelectVizier()
    {
        VizierLoader.selectedVizier = vizierCardDataContainer;
        SceneManager.LoadSceneAsync("VizierSelectedNewVersion");
    }

    public virtual void SetEfficiencyValues()
    {
        vizierName.text = vizierCardDataContainer.vizierName + "-" + vizierCardDataContainer.vizierLevel.ToString();
        EfficiencyData efficiencyData = vizierCardDataContainer.CalculateOverallPowerRaiseAtLevelUp();
        
        if (adWatched)
        {
            powerEfficiencyText.text = efficiencyData.powerEfficiency.ToString("N0");
            overallEfficiencyText.text = efficiencyData.overallEfficiency.ToString("N0");
            militaryEfficiencyText.text = efficiencyData.militaryEfficiency.ToString("N0");
            researchEfficiencyText.text = efficiencyData.researchEfficiency.ToString("N0");
            politicEfficiencyText.text = efficiencyData.politicEfficiency.ToString("N0");
            prestigeEfficiencyText.text = efficiencyData.prestigeEfficiency.ToString("N0");
        }

        else
        {
            powerEfficiencyText.text = "?";
            overallEfficiencyText.text = "?";
            militaryEfficiencyText.text = "?";
            researchEfficiencyText.text = "?";
            politicEfficiencyText.text = "?";
            prestigeEfficiencyText.text = "?";
        }

       
    }
}
