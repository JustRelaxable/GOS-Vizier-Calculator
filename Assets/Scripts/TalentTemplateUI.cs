using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentTemplateUI : MonoBehaviour
{
    public Talent talent;
    public Text talentName;
    public Text currentLevel;
    public Text currentStars;

    public Sprite militarySprite;
    public Sprite researchSprite;
    public Sprite politicSprite;
    public Sprite prestigeSprite;
    public Image talentIcon;

    public GameObject star;
    public GameObject starParent;
    public VizierTalentLevelSlider talentSlider;

    private void Start()
    {
        LoadTalent();
    }

    public void LoadTalent()
    {
        talentName.text = talent.talentName;
        currentLevel.text = "Level:" + (talent.currentStar / talent.talentStar).ToString();
        currentStars.text = "Current Stars:" + talent.currentStar;

        switch (talent.talentAttribute)
        {
            case Talent.talentAttributes.military:
                talentIcon.sprite = militarySprite;
                break;
            case Talent.talentAttributes.research:
                talentIcon.sprite = researchSprite;
                break;
            case Talent.talentAttributes.politic:
                talentIcon.sprite = politicSprite;
                break;
            case Talent.talentAttributes.prestige:
                talentIcon.sprite = prestigeSprite;
                break;
            default:
                break;
        }
        if(starParent.transform.childCount != talent.talentStar)
        {
            for (int i = 0; i < talent.talentStar; i++)
            {
                Instantiate(star, starParent.transform);
            }
        }
    }

    public void SendTalent()
    {
        talentSlider.gameObject.SetActive(true);
        talentSlider.LoadTalentAndSlider(talent);
    }

    public void ClearChildStars()
    {
        for (int i = 0; i < starParent.transform.childCount; i++)
        {
            Destroy(starParent.transform.GetChild(i).gameObject);
        }
    }
}
