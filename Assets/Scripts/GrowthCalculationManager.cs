using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GrowthCalculationManager : MonoBehaviour
{
    Vizier[] myViziersArray = new Vizier[DataManager.viziers.Count];
    VizierList myViziers = new VizierList();

    public Text goldText;
    public Text goldNeeded;
    public Text growthGain;

    public GameObject viziersParent;
    public GameObject vizierPanel;
    public GameObject referenceTransform;

    public Vector3 offset;

    private void Awake()
    {
        DataManager.viziers.CopyTo(myViziersArray);

        foreach (var item in myViziersArray)
        {
            myViziers.Add(item);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CalculateViziers()
    {
        System.Tuple<float, float> myVizierResults;
        myVizierResults = myViziers.CalculatePowerGrowthFromGold(long.Parse(goldText.text));

        growthGain.text = myVizierResults.Item1.ToString() + "Raise";
        goldNeeded.text = "You Need " + myVizierResults.Item2 + "Gold";


        for (int i = 0; i < myViziers.Count; i++)
        {
            GameObject panel = Instantiate(vizierPanel, referenceTransform.transform.position + (i * offset), Quaternion.identity, viziersParent.transform);
            panel.GetComponent<GrowthCalculationVizierPanel>().thisVizier = myViziers[i];
            panel.transform.SetParent(viziersParent.transform, false);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
