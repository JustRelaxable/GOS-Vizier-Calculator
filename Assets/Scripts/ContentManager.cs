using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContentManager : MonoBehaviour
{
    public GameObject vizierPanel;
    public GameObject vizierResearchPanel;
    public GameObject efficiencyPanel;
    public GameObject researchEfficiencyPanel;


    public GameObject[] vizierInstance;
    public GameObject[] vizierResearchInstance;
    public GameObject vizierInstanceParent;
    public GameObject vizierResearchParent;
    public Vector3 offset;
    Vector2 lastPos;

    private void Awake()
    {
        vizierInstance = new GameObject[DataManager.viziers.Count];
        DataManager.viziers.Sort();
        

        for (int i = 0; i < DataManager.viziers.Count; i++)
        {
            vizierInstance[i] = Instantiate(vizierPanel, transform.position + (i * offset), Quaternion.identity);
            //vizierInstance[i] = Instantiate(vizierPanel);
            vizierInstance[i].GetComponent<VizierOnList>().thisVizier = DataManager.viziers[i];
            vizierInstance[i].transform.SetParent(vizierInstanceParent.transform,false);

        }


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void ShowResearchEfficiency()
    {
        efficiencyPanel.SetActive(!efficiencyPanel.active);
        researchEfficiencyPanel.SetActive(!researchEfficiencyPanel.active);

        vizierResearchInstance = new GameObject[DataManager.viziers.Count];
        DataManager.viziers.Sort((x, y) => x.CalculateResearchEfficiency() > y.CalculateResearchEfficiency() ? 0 : 1);


        for (int i = 0; i < DataManager.viziers.Count; i++)
        {
            vizierResearchInstance[i] = Instantiate(vizierResearchPanel, transform.position + (i * offset), Quaternion.identity, vizierResearchParent.transform);
            //vizierInstance[i] = Instantiate(vizierPanel);
            vizierResearchInstance[i].GetComponent<VizierResearchEfficiency>().thisVizier = DataManager.viziers[i];
            //vizierResearchInstance[i].transform.SetParent(vizierResearchParent.transform, false);

        }
    }
}
