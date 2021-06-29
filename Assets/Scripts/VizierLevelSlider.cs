using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VizierLevelSlider : MonoBehaviour
{
    public Slider vizierLevelSlider;
    public Text vizierLevelText;

    private void Start()
    {
        vizierLevelSlider.value = VizierLoader.selectedVizier.vizierLevel;
        SetVizierLevelText();
    }

    public void SetVizierLevelText()
    {
        vizierLevelText.text = "Vizier Level:" + vizierLevelSlider.value.ToString();
    }

    public void SaveVizierLevel()
    {
        VizierLoader.selectedVizier.vizierLevel = (int)vizierLevelSlider.value;
        MyVizierList.SaveVizier();
    }

    public void IncreaseSliderValue()
    {
        vizierLevelSlider.value += 1;
    }

    public void DecreaseSliderValue()
    {
        vizierLevelSlider.value -= 1;
    }
}
