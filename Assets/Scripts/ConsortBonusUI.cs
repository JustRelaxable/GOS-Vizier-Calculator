using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsortBonusUI : MonoBehaviour
{
    VizierCardDataContainer selectedVizier;
    ConsortCardDataContainer ConsortCardDataContainer;

    public Text militaryBonusText;
    public Text researchBonusText;
    public Text politicBonusText;
    public Text prestigeBonusText;

    private void Awake()
    {
        selectedVizier = VizierLoader.selectedVizier;
        ConsortCardDataContainer = selectedVizier.consort;
    }
    void Start()
    {
        LoadBonusses();
    }

    public void LoadBonusses()
    {
        militaryBonusText.text = "%" + ConsortCardDataContainer.militaryRate.ToString();
        researchBonusText.text = "%" + ConsortCardDataContainer.researchRate.ToString();
        politicBonusText.text = "%" + ConsortCardDataContainer.politicRate.ToString();
        prestigeBonusText.text = "%" + ConsortCardDataContainer.prestigeRate.ToString();
    }
}
