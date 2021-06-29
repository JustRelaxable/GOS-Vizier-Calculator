using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class EfficiencyCardSpawner : MonoBehaviour
{
    public GameObject efficiencyCardObject;
    public GameObject canvas;
    public List<EfficiencyCard> efficiencyCardObjects = new List<EfficiencyCard>();
    public SortButton button;

    private void Start()
    {
        //GetMyViziers();
    }

    public void GetMyViziers()
    {
        List<VizierCardDataContainer> tempList = efficiencyCardObjects.Select(v => v.vizierCardDataContainer).ToList();
        IOrderedEnumerable<VizierCardDataContainer> orderedList = ListVizier(button.listing);
        MyVizierList.myViziers = new List<VizierCardDataContainer>(orderedList);

        for (int i = 0; i < MyVizierList.myViziers.Count; i++)
        {
            //if(tempList.Contains(MyVizierList.myViziers[i]))
            {
                GameObject spawnedEfficiencyCard = Instantiate(efficiencyCardObject, transform);
                spawnedEfficiencyCard.GetComponent<EfficiencyCard>().vizierCardDataContainer = MyVizierList.myViziers[i];
                spawnedEfficiencyCard.GetComponent<EfficiencyCard>().localizedText.key = MyVizierList.myViziers[i].vizierName;
                RectTransform spawnedRect = spawnedEfficiencyCard.GetComponent<RectTransform>();
                spawnedRect.sizeDelta = new Vector2(spawnedRect.sizeDelta.x, 358.81f);
                efficiencyCardObjects.Add(spawnedEfficiencyCard.GetComponent<EfficiencyCard>());
                //Sprite vizierImage = Sprite.Create(Resources.Load() as Texture2D, Rect.zero, Vector2.zero);
                spawnedEfficiencyCard.GetComponent<EfficiencyCard>().imageOfVizier.sprite = Resources.Load<Sprite>("VizierEfficiencyCardImages/" + (MyVizierList.myViziers[i].vizierIndex).ToString());
            }          
        }
    }

    private void Update()
    {
        if(canvas.activeInHierarchy == false)
        {
            
        }
    }

    public virtual IOrderedEnumerable<VizierCardDataContainer> ListVizier(EfficiencyListing listing)
    {
        switch (listing)
        {
            case EfficiencyListing.overall:
                return MyVizierList.myViziers.OrderByDescending(v => v.CalculateOverallPowerRaiseAtLevelUp().overallEfficiency);
            case EfficiencyListing.power:
                return MyVizierList.myViziers.OrderByDescending(v => v.CalculateOverallPowerRaiseAtLevelUp().powerEfficiency);
            case EfficiencyListing.military:
                return MyVizierList.myViziers.OrderByDescending(v => v.CalculateOverallPowerRaiseAtLevelUp().militaryEfficiency);
            case EfficiencyListing.research:
                return MyVizierList.myViziers.OrderByDescending(v => v.CalculateOverallPowerRaiseAtLevelUp().researchEfficiency);
            case EfficiencyListing.politic:
                return MyVizierList.myViziers.OrderByDescending(v => v.CalculateOverallPowerRaiseAtLevelUp().politicEfficiency);
            case EfficiencyListing.prestige:
                return MyVizierList.myViziers.OrderByDescending(v => v.CalculateOverallPowerRaiseAtLevelUp().prestigeEfficiency);
            default:
                return null;
        }     
    }

    public void ControlledGetViziers()
    {
        if (MyViziersListTabManager.isMyViziersOpened)
        {
            return;
        }

        else
        {
            GetMyViziers();
        }
    }

    public void ControlledGetBadgeEfficiency()
    {
        if (MyViziersListTabManager.isBadgeEfficiencyOpened)
        {
            return;
        }

        else
        {
            GetMyViziers();
        }
    }

    public void ControlledGetLevelEfficiency()
    {
        if (MyViziersListTabManager.isLevelEfficiencyOpened)
        {
            return;
        }

        else
        {
            GetMyViziers();
        }
    }

    public void RemoveChilds()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}

public enum EfficiencyListing
{
    overall,
    power,
    military,
    research,
    politic,
    prestige
}
