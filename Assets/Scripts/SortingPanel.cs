using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortingPanel : MonoBehaviour
{
    public SortingMethodChanger[] sortingMethodChangers;
    public Button levelButton;
    public Button badgeButton;
    public EfficiencyCardSpawner levelSpawner;
    public EfficiencyCardSpawner badgeSpawner;

    public void ChangeSpawner(Button button)
    {
        if(button == levelButton)
        {
            for (int i = 0; i < sortingMethodChangers.Length; i++)
            {
                sortingMethodChangers[i].spawner = levelSpawner;
            }
        }

        else if (button == badgeButton)
        {
            for (int i = 0; i < sortingMethodChangers.Length; i++)
            {
                sortingMethodChangers[i].spawner = badgeSpawner;
            }
        }

    }
}
