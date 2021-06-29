using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyViziersListTabManager : MonoBehaviour
{
    public static bool isMyViziersOpened = false;
    public static bool isBadgeEfficiencyOpened = false;
    public static bool isLevelEfficiencyOpened = false;
    public Button mineButton;
    public Button allButton;
    public Button badgeEfficiency;
    public Button levelEfficiency;
    public ScrollRect scrollRect;

    public RectTransform levelContent;
    public RectTransform badgeContent;

    private void Start()
    {
        ResetAttributes();
    }

    public static void ResetAttributes()
    {
        isMyViziersOpened = false;
        isBadgeEfficiencyOpened = false;
        isLevelEfficiencyOpened = false;
    }

    public void SetIsMyVizierOpened(Button button)
    {
        if(button == mineButton)
        {
            isMyViziersOpened = true;
        }

        else if(allButton == button)
        {
            isMyViziersOpened = false;
        }
    }

    public void SetIsEfficiencyOpened(Button button)
    {
        if (button == badgeEfficiency)
        {
            isBadgeEfficiencyOpened = true;
            isLevelEfficiencyOpened = false;
            scrollRect.content = badgeContent;
        }

        else if (levelEfficiency == button)
        {
            isBadgeEfficiencyOpened = false;
            isLevelEfficiencyOpened = true;
            scrollRect.content = levelContent;
        }
    }
}
