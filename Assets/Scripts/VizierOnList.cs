using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VizierOnList : MonoBehaviour
{
    public Vizier thisVizier;

    public Text vizierName;
    public Text vizierEfficiency;

    private void Awake()
    {
        
    }

    void Start()
    {
        vizierName.text = thisVizier.name;
        vizierEfficiency.text = thisVizier.CalculateRateOfEfficiency().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadVizier()
    {
        VizierSelectedManager.selectedStaticVizier = thisVizier;
        SceneManager.LoadScene("vizierSelected");
    }
}
