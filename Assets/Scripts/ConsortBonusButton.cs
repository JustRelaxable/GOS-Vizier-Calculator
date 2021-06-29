using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsortBonusButton : MonoBehaviour
{
    public VizierAttribute attribute;
    ConsortCardDataContainer consort;
    public ConsortBonusSlider consortBonusSlider;

    private void Awake()
    {
        consort = VizierLoader.selectedVizier.consort;
    }

    public void SendConsort()
    {
        consortBonusSlider.LoadSlider(attribute, consort);
    }
}
