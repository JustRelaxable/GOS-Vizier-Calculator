using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    interface IHarmony
    {
        float CalculateHarmonyPowerRaise(float militaryRaise, float researchRaise, float politicalRaise, float prestigeRaise, int magnificientFiveCount = 0, bool isMagnificientFive = false);
    }
}
