using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity.Modules;
using System.Linq;

public class SelectedVizier : MonoBehaviour
{
    public Text vizierNameText;
    public Text arenaBaseDamageText;
    VizierCardDataContainer selectedVizier;
    public SkeletonGraphicMultiObject vizierAnimation;

    private void Start()
    {
        selectedVizier = VizierLoader.selectedVizier;
        WriteVizierNameAndLevel();
        SetVizierAnimation();
        SetArenaDamageText();
    }

    public void WriteVizierNameAndLevel()
    {
        vizierNameText.text = selectedVizier.vizierName + " - " + selectedVizier.vizierLevel.ToString();
    }

    public void SetVizierAnimation()
    {
        VizierSpawner vizierSpawner = GameObject.FindObjectOfType<VizierSpawner>();
        VizierCard vizierCard = vizierSpawner.vizierCards.Single(v => v.vizierName == selectedVizier.vizierName) as VizierCard;
        vizierAnimation.SkeletonDataAsset = vizierCard.vizierSkeletonDataAsset;
        vizierAnimation.gameObject.GetComponent<RectTransform>().localScale = new Vector3(vizierCard.size, vizierCard.size, vizierCard.size);
        vizierAnimation.startingAnimation = "Idle";
        vizierAnimation.startingLoop = true;
        vizierAnimation.Initialize(false);
    }

    public void SetArenaDamageText()
    {
        arenaBaseDamageText.text = "Arena Base Damage\n" + selectedVizier.GetArenaDamage().ToString();
    }
}
