using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EfficiencyListCleaner : MonoBehaviour
{
    public GameObject efficiencyListContent;
    public GameObject badgeEfficiencyContent;
    public Image levelImage;
    public Image badgeImage;
    public EfficiencyButtonColorManager efficiencyButton;
    private void OnDisable()
    {
        foreach (Transform child in efficiencyListContent.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in badgeEfficiencyContent.transform)
        {
            Destroy(child.gameObject);
        }
        MyViziersListTabManager.ResetAttributes();
        efficiencyListContent.transform.parent.gameObject.SetActive(true);
        badgeEfficiencyContent.transform.parent.gameObject.SetActive(false);
        levelImage.color = efficiencyButton.selectedColor;
        badgeImage.color = efficiencyButton.normalColor;
    }

    public void ClearLevelChilds()
    {
        foreach (Transform child in efficiencyListContent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ClearBadgeChilds()
    {
        foreach (Transform child in badgeEfficiencyContent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
