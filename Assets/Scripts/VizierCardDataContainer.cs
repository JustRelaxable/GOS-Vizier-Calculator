using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[System.Serializable]
public class VizierCardDataContainer
{
    public string vizierName;
    public int vizierLevel;
    //readonly int multiplier = 1000000;
    public List<Talent> talents;
    public ConsortCardDataContainer consort = new ConsortCardDataContainer();
    public int vizierIndex;

    public VizierCardDataContainer(string name,int level,List<Talent> talentList,int index)
    {
        vizierName = name;
        vizierLevel = level;
        talents = talentList;
        vizierIndex = index;
    }

    public float GetGoldNeedForLevelUp()
    {
        if (vizierLevel < 200)
        {
            return (0.5f * Mathf.Pow(vizierLevel, 3) + 2f * Mathf.Pow(vizierLevel, 2) + 49.5f * Mathf.Pow(vizierLevel, 1) + 48f);
        }

        else if (vizierLevel >= 200 && vizierLevel < 250)
        {
            return (15.73f * Mathf.Pow(vizierLevel - 199, 3) + 3317.02f * Mathf.Pow(vizierLevel - 199, 2) + 261680.07f * Mathf.Pow(vizierLevel - 199, 1) + 4029015.15f);
        }

        else if (vizierLevel >= 250 && vizierLevel < 300)
        {
            return (18.99f * Mathf.Pow(vizierLevel - 249, 3) + 6086.01f * Mathf.Pow(vizierLevel - 249, 2) + 721391.53f * Mathf.Pow(vizierLevel - 249, 1) + 27494602.46f);
        }

        else if (vizierLevel >= 300 && vizierLevel < 400)
        {
            return (27.88f * Mathf.Pow(vizierLevel - 299, 3) + 9403.85f * Mathf.Pow(vizierLevel - 299, 2) + 1490579.26f * Mathf.Pow(vizierLevel - 299, 1) + 81353123.52f);
        }

        else if (vizierLevel >= 400)
        {
            return (2000000f * Mathf.Pow(vizierLevel - 399, 2) + 55000000f * Mathf.Pow(vizierLevel - 399, 1) + 1296000000f);
        }

        else
        {
            return 0;
        }
    }

    public EfficiencyData CalculateOverallPowerRaiseAtLevelUp()
    {
        TalentData talentData = CalculateAllTalents();
        return CreateEfficiencyData(talentData);    
    }

    public AttributeRaiseData CalculateAttributeRaise()
    {
        TalentData talentData = CalculateAllTalents();

        float powerNow = talentData.militaryStars * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        float powerLater = talentData.militaryStars * ((((vizierLevel) * (vizierLevel + 3)) * 0.1f) + 10);
        float deltaPower = powerLater - powerNow;
        float consortBonus = consort.GetGrowthBonus(VizierAttribute.military, deltaPower);
        float militaryGrowth = consortBonus + deltaPower;

        powerNow = talentData.researchStars * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        powerLater = talentData.researchStars * ((((vizierLevel) * (vizierLevel + 3)) * 0.1f) + 10);
        deltaPower = powerLater - powerNow;
        consortBonus = consort.GetGrowthBonus(VizierAttribute.research, deltaPower);
        float researchGrowth = consortBonus + deltaPower;

        powerNow = talentData.politicStars * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        powerLater = talentData.politicStars * ((((vizierLevel) * (vizierLevel + 3)) * 0.1f) + 10);
        deltaPower = powerLater - powerNow;
        consortBonus = consort.GetGrowthBonus(VizierAttribute.politic, deltaPower);
        float politicGrowth = consortBonus + deltaPower;

        powerNow = talentData.prestigeStars * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        powerLater = talentData.prestigeStars * ((((vizierLevel) * (vizierLevel + 3)) * 0.1f) + 10);
        deltaPower = powerLater - powerNow;
        consortBonus = consort.GetGrowthBonus(VizierAttribute.prestige, deltaPower);
        float prestigeGrowth = consortBonus + deltaPower;

        float currentPower = 5000 * vizierLevel * talentData.militaryStars;
        float nextPower = 5000 * (vizierLevel + 1) * talentData.militaryStars;
        float powerGrowth = nextPower - currentPower;

        return new AttributeRaiseData(militaryGrowth, researchGrowth, politicGrowth, prestigeGrowth, powerGrowth);
    }

    private EfficiencyData CreateEfficiencyData(TalentData talentData)
    {
        EfficiencyData efficiencyData = new EfficiencyData();
        float overall = 0;

        float powerNow = talentData.militaryStars * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        float powerLater = talentData.militaryStars * ((((vizierLevel) * (vizierLevel + 3)) * 0.1f) + 10);
        float deltaPower = powerLater - powerNow;
        float consortBonus = consort.GetGrowthBonus(VizierAttribute.military, deltaPower);
        float overallGrowth = consortBonus + deltaPower;
        overall += overallGrowth;
        efficiencyData.militaryEfficiency = Mathf.RoundToInt((overallGrowth / GetGoldNeedForLevelUp()) * Mathf.Pow(10f, 6));

        powerNow = talentData.researchStars * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        powerLater = talentData.researchStars * ((((vizierLevel) * (vizierLevel + 3)) * 0.1f) + 10);
        deltaPower = powerLater - powerNow;
        consortBonus = consort.GetGrowthBonus(VizierAttribute.research, deltaPower);
        overallGrowth = consortBonus + deltaPower;
        overall += overallGrowth;
        efficiencyData.researchEfficiency = Mathf.RoundToInt((overallGrowth / GetGoldNeedForLevelUp()) * Mathf.Pow(10f, 6));

        powerNow = talentData.politicStars * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        powerLater = talentData.politicStars * ((((vizierLevel) * (vizierLevel + 3)) * 0.1f) + 10);
        deltaPower = powerLater - powerNow;
        consortBonus = consort.GetGrowthBonus(VizierAttribute.politic, deltaPower);
        overallGrowth = consortBonus + deltaPower;
        overall += overallGrowth;
        efficiencyData.politicEfficiency = Mathf.RoundToInt((overallGrowth / GetGoldNeedForLevelUp()) * Mathf.Pow(10f, 6));

        powerNow = talentData.prestigeStars * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        powerLater = talentData.prestigeStars * ((((vizierLevel) * (vizierLevel + 3)) * 0.1f) + 10);
        deltaPower = powerLater - powerNow;
        consortBonus = consort.GetGrowthBonus(VizierAttribute.prestige, deltaPower);
        overallGrowth = consortBonus + deltaPower;
        overall += overallGrowth;
        efficiencyData.prestigeEfficiency = Mathf.RoundToInt((overallGrowth / GetGoldNeedForLevelUp()) * Mathf.Pow(10f, 6));

        efficiencyData.overallEfficiency = Mathf.RoundToInt((overall / GetGoldNeedForLevelUp()) * Mathf.Pow(10f, 6));

        float currentPower = 5000 * vizierLevel * talentData.militaryStars;
        float nextPower = 5000 * (vizierLevel + 1) * talentData.militaryStars;
        deltaPower = nextPower - currentPower;
        efficiencyData.powerEfficiency = Mathf.RoundToInt((deltaPower / GetGoldNeedForLevelUp()) * Mathf.Pow(10f, 5));

        return efficiencyData;
    }

    public TalentData CalculateAllTalents()
    {
        Array talentAttribute = Enum.GetValues(typeof(Talent.talentAttributes));
        List<Talent.talentAttributes> listOfTalentAttributes = talentAttribute.Cast<Talent.talentAttributes>().ToList();

        int militaryStars = 0;
        int researchStars = 0;
        int politicStars = 0;
        int prestigeStars = 0;

        for (int i = 0; i < listOfTalentAttributes.Count; i++)
        {
            int attributeStars = 0;

            for (int j = 0; j < talents.Count; j++)
            {
                if (talents[j].talentAttribute == listOfTalentAttributes[i])
                {
                    attributeStars += talents[j].currentStar;
                }
            }

            switch (listOfTalentAttributes[i])
            {
                case Talent.talentAttributes.military:
                    militaryStars = attributeStars;
                    break;
                case Talent.talentAttributes.research:
                    researchStars = attributeStars;
                    break;
                case Talent.talentAttributes.politic:
                    politicStars = attributeStars;
                    break;
                case Talent.talentAttributes.prestige:
                    prestigeStars = attributeStars;
                    break;
                default:
                    break;
            }
        }

        return new TalentData(militaryStars, researchStars, politicStars, prestigeStars);
    }

    public int GetArenaDamage()
    {
        int currentStars = 0;
        for (int i = 0; i < talents.Count; i++)
        {
            currentStars += talents[i].currentStar;
        }

        int arenaDamage = (currentStars * 100) + (20 - currentStars) * 10;
        return arenaDamage;
    }

    public BadgeEfficiencyData GetBadgeEfficiencyData()
    {
        TalentData talentData = CalculateAllTalents();
        BadgeEfficiencyData badgeEfficiencyData = new BadgeEfficiencyData();

        float powerNow = talentData.militaryStars * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        float powerLater= (talentData.militaryStars+1) * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        float deltaPower = powerLater - powerNow;
        float consortBonus = consort.GetGrowthBonus(VizierAttribute.military, deltaPower);
        float overallGrowth = consortBonus + deltaPower;
        badgeEfficiencyData.militaryEfficiency = overallGrowth;

        powerNow = talentData.researchStars * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        powerLater = (talentData.researchStars+1) * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        deltaPower = powerLater - powerNow;
        consortBonus = consort.GetGrowthBonus(VizierAttribute.research, deltaPower);
        overallGrowth = consortBonus + deltaPower;
        badgeEfficiencyData.researchEfficiency = overallGrowth;

        powerNow = talentData.politicStars * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        powerLater = (talentData.politicStars + 1) * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        deltaPower = powerLater - powerNow;
        consortBonus = consort.GetGrowthBonus(VizierAttribute.politic, deltaPower);
        overallGrowth = consortBonus + deltaPower;
        badgeEfficiencyData.politicEfficiency = overallGrowth;

        powerNow = talentData.prestigeStars * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        powerLater = (talentData.prestigeStars + 1) * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        deltaPower = powerLater - powerNow;
        consortBonus = consort.GetGrowthBonus(VizierAttribute.prestige, deltaPower);
        overallGrowth = consortBonus + deltaPower;
        badgeEfficiencyData.prestigeEfficiency = overallGrowth;

        float currentPower = 5000 * vizierLevel * talentData.militaryStars;
        float nextPower = 5000 * (vizierLevel) * (talentData.militaryStars+1);
        deltaPower = nextPower - currentPower;
        badgeEfficiencyData.powerEfficiency = deltaPower;

        return badgeEfficiencyData;
    }
}

public class TalentData
{
    public int militaryStars;
    public int researchStars;
    public int politicStars;
    public int prestigeStars;

    public TalentData(int milS,int resS,int polS,int preS)
    {
        militaryStars = milS;
        researchStars = resS;
        politicStars = polS;
        prestigeStars = preS;
    }
}

public class AttributeRaiseData
{
    public float militaryRaise;
    public float researchRaise;
    public float politicRaise;
    public float prestigeRaise;
    public float powerRaise;
    public float overallRaise;

    public AttributeRaiseData(float milR,float resR,float polR,float preR,float powR)
    {
        militaryRaise = milR;
        researchRaise = resR;
        politicRaise = polR;
        prestigeRaise = preR;
        powerRaise = powR;
        overallRaise = milR + resR + polR + preR;
    }
}

public class BadgeEfficiencyData
{
    public float militaryEfficiency;
    public float researchEfficiency;
    public float politicEfficiency;
    public float prestigeEfficiency;
    public float powerEfficiency;
}
