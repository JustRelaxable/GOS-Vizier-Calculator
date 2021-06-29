using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class VizierList : List<Vizier>
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Tuple<float,float> CalculatePowerGrowthFromGold(long gold)
    {
        float initialGold = gold;
        float remainingGold = initialGold;
        float powerRaise = 0;

        bool isEnough = false;
        do
        {
            this.Sort();

            float goldUsage = remainingGold;

            for (int i = 0; i < this.Count; i++)
            {
                if (remainingGold > this[i].CalculateGoldForLevelUp())
                {
                    powerRaise += this[i].CalculateOverallPowerRaiseAtLevelUp();
                    remainingGold -= this[i].CalculateGoldForLevelUp();
                    this[i].vizierLevel += 1;
                    break;
                }
            }

            if(goldUsage == remainingGold)
            {
                isEnough = true;
            }
        }
        while (remainingGold >= 0f && !isEnough);

        return new Tuple<float, float>(powerRaise, remainingGold);
    }
}
