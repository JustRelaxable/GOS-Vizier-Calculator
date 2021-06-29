using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingMethodChanger : MonoBehaviour
{
    public SortButton button;
    public EfficiencyListing listingMethod;
    public EfficiencyCardSpawner spawner;

    public void ApplyChanges()
    {
        button.listing = listingMethod;
        spawner.RemoveChilds();
        spawner.GetMyViziers();
    }
}
