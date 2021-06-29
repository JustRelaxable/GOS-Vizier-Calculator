using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class VizierCreationManager : MonoBehaviour
{
    public InputField vizierName;
    public InputField vizierLevel;
    public InputField vizierMilitaryTalent;
    public InputField vizierResearchTalent;
    public InputField vizierPoliticalTalent;
    public InputField vizierPrestigeTalent;
    public InputField consortMilitaryRate;
    public InputField consortResearchRate;
    public InputField consortPoliticalRate;
    public InputField consortPrestigeRate;
    public Toggle isMagnificientFive;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateVizier()
    {
        Vizier vizier = new Vizier();

        vizier.name = vizierName.text;
        vizier.vizierLevel = Convert.ToInt32(vizierLevel.text);
        vizier.militaryTalents = Convert.ToInt32(vizierMilitaryTalent.text);
        vizier.researchTalents = Convert.ToInt32(vizierResearchTalent.text);
        vizier.politicalTalents = Convert.ToInt32(vizierPoliticalTalent.text);
        vizier.prestigeTalents = Convert.ToInt32(vizierPrestigeTalent.text);
        vizier.vizierConsort.militaryRate = (float.Parse(consortMilitaryRate.text)*0.01f);
        vizier.vizierConsort.researchRate = (float.Parse(consortResearchRate.text)*0.01f);
        vizier.vizierConsort.politicalRate = (float.Parse(consortPoliticalRate.text)*0.01f);
        vizier.vizierConsort.prestigeRate = (float.Parse(consortPrestigeRate.text)*0.01f);
        vizier.isMagnificientFive = isMagnificientFive.isOn;

        DataManager.SaveVizier(vizier);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void OpenVizierListing()
    {
        SceneManager.LoadScene("listViziers");
    }
}
