using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity.Modules;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class VizierCardReader : MonoBehaviour
{
    public VizierCard vizierCard;
    public ConfirmatioPanel confirmationPanel;
    public static VizierListEvent vizierSelected = new VizierListEvent();

    public Sprite[] vizierHonorBadges;
    public Sprite[] vizierBGs;

    public Text vizierLevel;
    public Image vizierBG;
    public Image vizierHonorBadge;
    public SkeletonGraphicMultiObject animationRenderer;
    Toggle cardToggle;

    private void Awake()
    {
        cardToggle = GetComponent<Toggle>();
        confirmationPanel = GameObject.FindObjectOfType<ConfirmatioPanel>();
    }
    void Start()
    {
        int vizierIndex = CheckVizierToggle();

        if (vizierIndex >= 0)
        {
            vizierLevel.text = MyVizierList.myViziers[vizierIndex].vizierLevel.ToString();
        }

        else
        {
            vizierLevel.text = vizierCard.vizierLevel.ToString();
        }

        
        animationRenderer.SkeletonDataAsset = vizierCard.vizierSkeletonDataAsset;
        SetVizierBadgeandBG();

        if(vizierCard.YPositionFix != 0)
        {
            RectTransform rectVizier = animationRenderer.gameObject.GetComponent<RectTransform>();
            Vector3 yFixVector3 = new Vector3(rectVizier.localPosition.x, vizierCard.YPositionFix, rectVizier.localPosition.z);
            rectVizier.localPosition = yFixVector3;
        }

        animationRenderer.startingAnimation = "Idle";
        animationRenderer.startingLoop = true;
        animationRenderer.Initialize(false);
    }

    public void Update()
    {
        animationRenderer.Initialize(false);
    }

    private void SetVizierBadgeandBG()
    {
        if (int.Parse(vizierLevel.text) < 100)
        {
            vizierBG.sprite = vizierBGs[0];
            vizierHonorBadge.sprite = vizierHonorBadges[0];
        }

        else if(int.Parse(vizierLevel.text) >= 100 && int.Parse(vizierLevel.text) < 150)
        {
            vizierBG.sprite = vizierBGs[1];
            vizierHonorBadge.sprite = vizierHonorBadges[1];
        }

        else if (int.Parse(vizierLevel.text) >= 150 && int.Parse(vizierLevel.text) < 200)
        {
            vizierBG.sprite = vizierBGs[2];
            vizierHonorBadge.sprite = vizierHonorBadges[2];
        }

        else if (int.Parse(vizierLevel.text) >= 200 && int.Parse(vizierLevel.text) < 250)
        {
            vizierBG.sprite = vizierBGs[3];
            vizierHonorBadge.sprite = vizierHonorBadges[3];
        }

        else if (int.Parse(vizierLevel.text) >= 250 && int.Parse(vizierLevel.text) < 300)
        {
            vizierBG.sprite = vizierBGs[4];
            vizierHonorBadge.sprite = vizierHonorBadges[4];
        }

        else if (int.Parse(vizierLevel.text) >= 300 && int.Parse(vizierLevel.text) < 350)
        {
            vizierBG.sprite = vizierBGs[5];
            vizierHonorBadge.sprite = vizierHonorBadges[5];
        }

        else if (int.Parse(vizierLevel.text) >= 350 && int.Parse(vizierLevel.text) < 400)
        {
            vizierBG.sprite = vizierBGs[6];
            vizierHonorBadge.sprite = vizierHonorBadges[6];
        }

        else if(int.Parse(vizierLevel.text) >= 400)
        {
            vizierBG.sprite = vizierBGs[7];
            vizierHonorBadge.sprite = vizierHonorBadges[7];
        }
    }

    public void OnToggleChange()
    {
        if (GetComponent<Toggle>().isOn)
        {
            MyVizierList.AddVizier(vizierCard);
        }

        else
        {
            vizierSelected.Invoke(vizierCard,GetComponent<Toggle>());
            //MyVizierList.DeleteViziers(vizierCard);
        }
    }

    public int CheckVizierToggle()
    {
        for (int i = 0; i < MyVizierList.myViziers.Count; i++)
        {
            if(MyVizierList.myViziers[i].vizierName == vizierCard.vizierName)
            {
                cardToggle.isOn = true;
                return i;
            }
        }
        return -1;
    }
}

public class VizierListEvent : UnityEvent<VizierCard, Toggle>
{

}
