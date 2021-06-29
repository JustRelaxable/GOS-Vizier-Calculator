using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConsortCardDataContainer
{
    public string consortName;
    public float militaryRate;
    public float researchRate;
    public float politicRate;
    public float prestigeRate;

    public float GetGrowthBonus(VizierAttribute attribute,float powerGrowth)
    {
        switch (attribute)
        {
            case VizierAttribute.military:
                return (powerGrowth * (militaryRate * 0.01f));
            case VizierAttribute.politic:
                return (powerGrowth * (politicRate * 0.01f));
            case VizierAttribute.research:
                return (powerGrowth * (researchRate * 0.01f));
            case VizierAttribute.prestige:
                return (powerGrowth * (prestigeRate * 0.01f));
            default:
                return 0;
        }
    }
}

public enum VizierAttribute
{
    military,
    politic,
    research,
    prestige
}
