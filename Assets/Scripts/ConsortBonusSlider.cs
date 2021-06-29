using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsortBonusSlider : MonoBehaviour
{
    VizierAttribute comingAttribute;
    ConsortCardDataContainer consort;
    public Slider slider;
    public Text bonusText;


    public void LoadSlider(VizierAttribute attribute, ConsortCardDataContainer cnsrt)
    {
        comingAttribute = attribute;
        consort = cnsrt;

        switch (attribute)
        {
            case VizierAttribute.military:
                bonusText.text = "Military Bonus = %" + (consort.militaryRate).ToString();
                slider.value = (int)(consort.militaryRate / 0.1f);
                break;
            case VizierAttribute.politic:
                bonusText.text = "Political Bonus = %" + (consort.politicRate).ToString();
                slider.value = (int)(consort.politicRate / 0.1f);
                break;
            case VizierAttribute.research:
                bonusText.text = "Research Bonus = %" + (consort.researchRate).ToString();
                slider.value = (int)(consort.researchRate / 0.1f);
                break;
            case VizierAttribute.prestige:
                bonusText.text = "Prestige Bonus = %" + (consort.prestigeRate).ToString();
                slider.value = (int)(consort.prestigeRate / 0.1f);
                break;
            default:
                break;
        }
    }

    public void OnValueChange()
    {
        switch (comingAttribute)
        {
            case VizierAttribute.military:
                bonusText.text = "Military Bonus = %" + (slider.value * 0.1f).ToString();
                break;
            case VizierAttribute.politic:
                bonusText.text = "Political Bonus = %" + (slider.value * 0.1f).ToString();
                break;
            case VizierAttribute.research:
                bonusText.text = "Research Bonus = %" + (slider.value * 0.1f).ToString();
                break;
            case VizierAttribute.prestige:
                bonusText.text = "Prestige Bonus = %" + (slider.value * 0.1f).ToString();
                break;
            default:
                break;
        }
    }

    public void ApplyChanges()
    {
        switch (comingAttribute)
        {
            case VizierAttribute.military:
                consort.militaryRate = (slider.value * 0.1f);
                break;
            case VizierAttribute.politic:
                consort.politicRate = (slider.value * 0.1f);
                break;
            case VizierAttribute.research:
                consort.researchRate = (slider.value * 0.1f);
                break;
            case VizierAttribute.prestige:
                consort.prestigeRate = (slider.value * 0.1f);
                break;
            default:
                break;
        }

        MyVizierList.SaveVizier();
    }

    public void IncreaseSliderValue()
    {
        slider.value += 1;
    }

    public void DecreaseSliderValue()
    {
        slider.value -= 1;
    }
}
