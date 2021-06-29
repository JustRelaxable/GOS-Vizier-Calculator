using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VizierSelectedManager : MonoBehaviour
{
    public static Vizier selectedStaticVizier;

    Vizier selectedVizier;

    public Text vizierName;

    public Button militaryTIncrease;
    public Button militaryTDecrease;
    public Button politicalTIncrease;
    public Button politicalTDecrease;
    public Button researchTIncrease;
    public Button researchTDecrease;
    public Button prestigeTIncrease;
    public Button prestigeTDecrease;

    public Button militaryCIncrease;
    public Button militaryCDecrease;
    public Button politicalCIncrease;
    public Button politicalCDecrease;
    public Button researchCIncrease;
    public Button researchCDecrease;
    public Button prestigeCIncrease;
    public Button prestigeCDecrease;

    public Button back;
    public Button detailed;

    public Text militaryT;
    public Text politicalT;
    public Text researchT;
    public Text prestigeT;

    public Text militaryC;
    public Text politicalC;
    public Text researchC;
    public Text prestigeC;

    public void Awake()
    {
        selectedVizier = selectedStaticVizier;
        LoadVizierAndUI();
    }

    

    public void LoadVizierAndUI()
    {
        vizierName.text = selectedVizier.name;

        militaryT.text = selectedVizier.militaryTalents.ToString();
        researchT.text = selectedVizier.researchTalents.ToString();
        politicalT.text = selectedVizier.politicalTalents.ToString();
        prestigeT.text = selectedVizier.prestigeTalents.ToString();

        militaryC.text = (selectedVizier.vizierConsort.militaryRate * 100).ToString();
        researchC.text = (selectedVizier.vizierConsort.researchRate * 100).ToString();
        politicalC.text = (selectedVizier.vizierConsort.politicalRate * 100).ToString();
        prestigeC.text = (selectedVizier.vizierConsort.prestigeRate * 100).ToString();
    }

    public void IncreaseMilitaryT()
    {
        selectedVizier.militaryTalents += 1;
        LoadVizierAndUI();
    }

    public void DecreaseMilitaryT()
    {
        selectedVizier.militaryTalents -= 1;
        LoadVizierAndUI();
    }

    public void IncreasePoliticalT()
    {
        selectedVizier.politicalTalents += 1;
        LoadVizierAndUI();
    }

    public void DecreasePoliticalT()
    {
        selectedVizier.politicalTalents -= 1;
        LoadVizierAndUI();
    }

    public void IncreaseResearchT()
    {
        selectedVizier.researchTalents += 1;
        LoadVizierAndUI();
    }

    public void DecreaseResearchT()
    {
        selectedVizier.researchTalents -= 1;
        LoadVizierAndUI();
    }

    public void IncreasePrestigeT()
    {
        selectedVizier.prestigeTalents += 1;
        LoadVizierAndUI();
    }

    public void DecreasePrestigeT()
    {
        selectedVizier.prestigeTalents -= 1;
        LoadVizierAndUI();
    }

    public void IncreaseMilitaryC()
    {
        selectedVizier.vizierConsort.militaryRate += 0.001f;
        LoadVizierAndUI();
    }

    public void DecreaseMilitaryC()
    {
        selectedVizier.vizierConsort.militaryRate -= 0.001f;
        LoadVizierAndUI();
    }

    public void IncreasePoliticalC()
    {
        selectedVizier.vizierConsort.politicalRate += 0.001f;
        LoadVizierAndUI();
    }

    public void DecreasePoliticalC()
    {
        selectedVizier.vizierConsort.politicalRate -= 0.001f;
        LoadVizierAndUI();
    }

    public void IncreaseResearchC()
    {
        selectedVizier.vizierConsort.researchRate += 0.001f;
        LoadVizierAndUI();
    }

    public void DecreaseResearchC()
    {
        selectedVizier.vizierConsort.researchRate -= 0.001f;
        LoadVizierAndUI();
    }

    public void IncreasePrestigeC()
    {
        selectedVizier.vizierConsort.prestigeRate += 0.001f;
        LoadVizierAndUI();
    }

    public void DecreasePrestigeC()
    {
        selectedVizier.vizierConsort.prestigeRate -= 0.001f;
        LoadVizierAndUI();
    }

    public void UpdateVizier()
    {
        DataManager.UpdateViziers();
    }

    public void GoBackToLisy()
    {
        SceneManager.LoadScene("listViziers");
    }

    public void GoDetailed()
    {
        SceneManager.LoadScene("detailedTab");
    }

}
