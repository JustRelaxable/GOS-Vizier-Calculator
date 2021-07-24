using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdCounter : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isAdShown = false;
    public static AdCounter instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (!isAdShown)
        {
            SceneManager.sceneLoaded += ShowAds;
        }
    }

    private void ShowAds(Scene arg0, LoadSceneMode arg1)
    {
        if(arg0.name == "ListViziersNewVersion")
        {
            isAdShown = true;
            SceneManager.sceneLoaded -= ShowAds;
            AdManager.instance.LoadFirstLoadAd();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
