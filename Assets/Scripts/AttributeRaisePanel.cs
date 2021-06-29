using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class AttributeRaisePanel : MonoBehaviour
{
    public Text militaryGrowth;
    public Text powerGrowth;
    public Text researchGrowth;
    public Text goldNeeded;
    public Text overallGrowth;
    public Text politicGrowth;
    public Text prestigeGrowth;

    private VizierCardDataContainer selectedVizier;

    private void Awake()
    {
        selectedVizier = VizierLoader.selectedVizier;
    }
    private void Start()
    {
        
        RefreshStats();
    }

    public void RefreshStats()
    {
        AttributeRaiseData data = selectedVizier.CalculateAttributeRaise();

        militaryGrowth.text = Mathf.RoundToInt(data.militaryRaise).ToString("N0");
        powerGrowth.text = Mathf.RoundToInt(data.powerRaise).ToString("N0");
        researchGrowth.text = Mathf.RoundToInt(data.researchRaise).ToString("N0");
        goldNeeded.text = AbbrevationUtility.AbbreviateNumber(selectedVizier.GetGoldNeedForLevelUp()).ToString();
        overallGrowth.text = Mathf.RoundToInt(data.overallRaise).ToString("N0");
        politicGrowth.text = Mathf.RoundToInt(data.politicRaise).ToString("N0");
        prestigeGrowth.text = Mathf.RoundToInt(data.prestigeRaise).ToString("N0");
    }
}

public static class AbbrevationUtility
{
    private static readonly SortedDictionary<int, string> abbrevations = new SortedDictionary<int, string>
     {
         {1000,"K"},
         {1000000, "M" },
         {1000000000, "B" }
     };

    public static string AbbreviateNumber(float number)
    {
        for (int i = abbrevations.Count - 1; i >= 0; i--)
        {
            KeyValuePair<int, string> pair = abbrevations.ElementAt(i);
            if (Mathf.Abs(number) >= pair.Key)
            {
                float roundedNumber = (number / pair.Key);
                roundedNumber = Round(roundedNumber, 2);
                return roundedNumber.ToString() + pair.Value;
            }
        }
        return number.ToString();
    }

    public static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }
}
