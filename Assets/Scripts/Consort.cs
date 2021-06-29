using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using System;

[Serializable]
public class Consort
{
    public float militaryRate;
    public float researchRate;
    public float politicalRate;
    public float prestigeRate;
    
    

    public float CalculateHarmonyPowerRaise(float militaryRaise, float researchRaise, float politicalRaise, float prestigeRaise,int magnificientFiveCount,bool isMagnificientFive)
    {
        if (!isMagnificientFive)
        {
            float military = militaryRaise * militaryRate;
            float research = researchRaise * researchRate;
            float political = politicalRaise * politicalRate;
            float prestige = prestigeRaise * prestigeRate;
            return (military + research + political + prestige);
        }

        else
        {
            return militaryRaise * (magnificientFiveCount * 20 * 0.01f);
        }
    }

    public float CalculateHarmonyResearchRaise(float researchRaise)
    {
        return (researchRaise * researchRate);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
