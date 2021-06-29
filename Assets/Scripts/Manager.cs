using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);    
    } 

    void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCreateVizier()
    {
        SceneManager.LoadScene("vizierCreate");
    }
     public void LoadListViziers()
    {
        SceneManager.LoadScene("listViziers");
    }

    public void DeleteViziers()
    {
        DataManager.DeleteViziers();
    }

    public void LoadCalculateGrowth()
    {
        SceneManager.LoadScene("growthCalculation");
    }
    
}
