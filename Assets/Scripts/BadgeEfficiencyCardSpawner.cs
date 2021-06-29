using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BadgeEfficiencyCardSpawner : EfficiencyCardSpawner
{
    public override IOrderedEnumerable<VizierCardDataContainer> ListVizier(EfficiencyListing listing)
    {
        switch (listing)
        {
            case EfficiencyListing.overall:
            case EfficiencyListing.power:
                return MyVizierList.myViziers.OrderByDescending(v => v.GetBadgeEfficiencyData().powerEfficiency);
            case EfficiencyListing.military:
                return MyVizierList.myViziers.OrderByDescending(v => v.GetBadgeEfficiencyData().militaryEfficiency);
            case EfficiencyListing.research:
                return MyVizierList.myViziers.OrderByDescending(v => v.GetBadgeEfficiencyData().researchEfficiency);
            case EfficiencyListing.politic:
                return MyVizierList.myViziers.OrderByDescending(v => v.GetBadgeEfficiencyData().politicEfficiency);
            case EfficiencyListing.prestige:
                return MyVizierList.myViziers.OrderByDescending(v => v.GetBadgeEfficiencyData().prestigeEfficiency);
            default:
                return null;
        }
    }
}
