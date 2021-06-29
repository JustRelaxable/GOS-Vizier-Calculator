using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Vizier : IComparable<Vizier>

{
    public int vizierLevel;
    public string name;
    public int militaryTalents;
    public int researchTalents;
    public int politicalTalents;
    public int prestigeTalents;
    public bool isMagnificientFive;

    public Consort vizierConsort = new Consort();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float CalculateOverallPowerRaiseAtLevelUp()
    {
        int allTalents = militaryTalents + politicalTalents + prestigeTalents + researchTalents;
        float powerNow = allTalents * (((vizierLevel - 1) * (vizierLevel + 2) * 0.1f) + 10);
        float powerLater = allTalents * ((((vizierLevel - 0) * (vizierLevel + 3)) * 0.1f) + 10);
        float consortBonus = vizierConsort.CalculateHarmonyPowerRaise(
            CalcuteAttributeRaise(militaryTalents),
            CalcuteAttributeRaise(researchTalents),
            CalcuteAttributeRaise(politicalTalents), CalcuteAttributeRaise(prestigeTalents),
            0,
            isMagnificientFive);
        return (powerLater - powerNow) + consortBonus;
    }

    public float CalculateGoldForLevelUp()
    {
        float calculatedGold = 0.5f * Mathf.Pow(vizierLevel, 3) + 2.0f * Mathf.Pow(vizierLevel, 2) + 49.5f * vizierLevel + 48.0f;
        return calculatedGold;
    }

    public float CalculateRateOfEfficiency()
    {
        return CalculateOverallPowerRaiseAtLevelUp() / CalculateGoldForLevelUp() * 10000;
    }

    public float CalculateResearchEfficiency()
    {
        float researchRaise = CalcuteAttributeRaise(researchTalents);
        float researchConsortBonus = vizierConsort.CalculateHarmonyResearchRaise(researchRaise);
        return (researchRaise + researchConsortBonus) / CalculateGoldForLevelUp() * 10000;
    }

    public float CalcuteAttributeRaise(int talent)
    {
        float powerNow = talent * ((((vizierLevel - 1) * (vizierLevel + 2)) * 0.1f) + 10);
        float powerLater = talent * ((((vizierLevel) * (vizierLevel + 3)) * 0.1f) + 10);
        return powerLater - powerNow;
    }

    public int CompareTo(Vizier other)
    {
        return other.CalculateRateOfEfficiency().CompareTo(this.CalculateRateOfEfficiency());
    }
}
