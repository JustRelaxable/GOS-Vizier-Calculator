using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VizierTalentTab : MonoBehaviour
{
    VizierCardDataContainer selectedVizier;
    public GameObject parentContent;
    public GameObject talentTemplate;
    public VizierTalentLevelSlider VizierTalentLevelSlider;

    private void Start()
    {
        selectedVizier = VizierLoader.selectedVizier;
        LoadTalentTemplates();
    }

    public void LoadTalentTemplates()
    {
        for (int i = 0; i < selectedVizier.talents.Count; i++)
        {
            GameObject spawnedTemplate = Instantiate(talentTemplate,parentContent.transform);
            spawnedTemplate.GetComponent<TalentTemplateUI>().talentSlider = VizierTalentLevelSlider;
            spawnedTemplate.GetComponent<TalentTemplateUI>().talent = selectedVizier.talents[i];
        }
    }

    public void ClearContent()
    {
        for (int i = 0; i < parentContent.transform.childCount; i++)
        {
            Destroy(parentContent.transform.GetChild(i).gameObject);
        }
    }
}
