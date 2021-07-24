using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeEfficiencyCard : EfficiencyCard
{
    private void Start()
    {
        SetEfficiencyValues();
    }

    public override void SetEfficiencyValues()
    {
        BadgeEfficiencyData badgeEfficiencyData = vizierCardDataContainer.GetBadgeEfficiencyData();
        if (adWatched)
        {
            powerEfficiencyText.text = badgeEfficiencyData.powerEfficiency.ToString("N0");
            militaryEfficiencyText.text = badgeEfficiencyData.militaryEfficiency.ToString("N0");
            researchEfficiencyText.text = badgeEfficiencyData.researchEfficiency.ToString("N0");
            politicEfficiencyText.text = badgeEfficiencyData.politicEfficiency.ToString("N0");
            prestigeEfficiencyText.text = badgeEfficiencyData.prestigeEfficiency.ToString("N0");
        }

        else
        {
            powerEfficiencyText.text = "?";
            militaryEfficiencyText.text = "?";
            researchEfficiencyText.text = "?";
            politicEfficiencyText.text = "?";
            prestigeEfficiencyText.text ="?";
        }

        
    }
}
