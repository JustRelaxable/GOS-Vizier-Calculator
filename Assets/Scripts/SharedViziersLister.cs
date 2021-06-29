using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedViziersLister : MonoBehaviour
{
    public GameObject efficiencyCardTemplate;
    public Transform parentTransform;
    public static ShareClass incomingViziers;


    private void Start()
    {
        PutVizierCardsOnTemplates();
        VizierLoader.from = sceneFrom.sharedViziers;
    }

    public void PutVizierCardsOnTemplates()
    {
        EfficiencyCard.adWatched = true;
        for (int i = 0; i < incomingViziers.vizierList.Count; i++)
        {
            GameObject instantiatedCard = Instantiate(efficiencyCardTemplate, parentTransform);
            instantiatedCard.GetComponent<EfficiencyCard>().vizierCardDataContainer = incomingViziers.vizierList[i];
            RectTransform spawnedRect = instantiatedCard.GetComponent<RectTransform>();
            spawnedRect.sizeDelta = new Vector2(spawnedRect.sizeDelta.x, 358.81f);
            instantiatedCard.GetComponent<EfficiencyCard>().imageOfVizier.sprite = Resources.Load<Sprite>("VizierEfficiencyCardImages/" + (incomingViziers.vizierList[i].vizierIndex).ToString());
        }
    }
}
