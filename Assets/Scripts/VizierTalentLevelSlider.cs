using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VizierTalentLevelSlider : MonoBehaviour
{
    public TalentTemplateUI talentTemplateUI;
    public Slider slider;
    VizierCardDataContainer selectedVizier;
    Talent comingTalent;
    public SelectedVizier vizierUI;

    private void Awake()
    {
        selectedVizier = VizierLoader.selectedVizier;
    }

    public void LoadTalentAndSlider(Talent talent)
    {
        comingTalent = talent;
        talentTemplateUI.talent = talent;
        talentTemplateUI.LoadTalent();
        slider.minValue = 1;
        SetSliderMaxValue();
        slider.value = (int)(talent.currentStar / talent.talentStar);
    }

    private void SetSliderMaxValue()
    {
        if (selectedVizier.vizierLevel < 100)
        {
            slider.maxValue = 50;
        }

        else if (selectedVizier.vizierLevel < 150)
        {
            slider.maxValue = 100;
        }

        else if (selectedVizier.vizierLevel < 200)
        {
            slider.maxValue = 150;
        }

        else if (selectedVizier.vizierLevel < 250)
        {
            slider.maxValue = 200;
        }

        else if (selectedVizier.vizierLevel < 300)
        {
            slider.maxValue = 250;
        }

        else if (selectedVizier.vizierLevel < 350)
        {
            slider.maxValue = 300;
        }

        else if (selectedVizier.vizierLevel < 400)
        {
            slider.maxValue = 350;
        }
    }

    public void SetTalentLevel()
    {
        comingTalent.currentStar = (int)slider.value * (int)comingTalent.talentStar;
        MyVizierList.SaveVizier();
        vizierUI.SetArenaDamageText();
        talentTemplateUI.LoadTalent();
    }

    public void IncreaseSliderValue()
    {
        slider.value += 1;
        SetTalentLevel();
    }

    public void DecreaseSliderValue()
    {
        slider.value -= 1;
        SetTalentLevel();
    }
}
