using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Talent
{
    public string talentName;
    public int talentStar;
    public int currentStar;
    public talentAttributes talentAttribute;

    public enum talentAttributes
    {
        military,
        research,
        politic,
        prestige
    }
}
