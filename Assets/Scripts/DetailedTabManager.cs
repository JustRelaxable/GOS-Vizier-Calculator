using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetailedTabManager : MonoBehaviour
{
    public Text militaryRaise;
    public Text politicalRaise;
    public Text researchRaise;
    public Text prestigeRaise;
    public Text numberOneEfficiency;
    public Text overall;
    public Text efficiency;
    public Text vizierName;
    public Text vizierLevel;






    void Start()
    {
        LoadUI();
    }

    public void LoadUI()
    {
        Vizier selectedVizier = VizierSelectedManager.selectedStaticVizier;
        militaryRaise.text = selectedVizier.CalcuteAttributeRaise(selectedVizier.militaryTalents).ToString();
        politicalRaise.text = selectedVizier.CalcuteAttributeRaise(selectedVizier.politicalTalents).ToString();
        researchRaise.text = selectedVizier.CalcuteAttributeRaise(selectedVizier.researchTalents).ToString();
        prestigeRaise.text = selectedVizier.CalcuteAttributeRaise(selectedVizier.prestigeTalents).ToString();
        vizierLevel.text = selectedVizier.vizierLevel.ToString();

        vizierName.text = selectedVizier.name;
        overall.text = selectedVizier.CalculateOverallPowerRaiseAtLevelUp().ToString();
        efficiency.text = selectedVizier.CalculateRateOfEfficiency().ToString();

        DataManager.viziers.Sort();
        numberOneEfficiency.text = DataManager.viziers[0].name;
    }

    public void IncreaseLevel()
    {
        VizierSelectedManager.selectedStaticVizier.vizierLevel += 1;
        LoadUI();
    }

    public void DecreaseLevel()
    {
        VizierSelectedManager.selectedStaticVizier.vizierLevel -= 1;
        LoadUI();
    }

    public void BackToSelectedVizier()
    {
        SceneManager.LoadScene("vizierSelected");
    }

    public void DeleteVizier()
    {
        DataManager.viziers.Remove(VizierSelectedManager.selectedStaticVizier);
        DataManager.UpdateViziers();
        SceneManager.LoadScene("mainMenu");
    }
 
}
