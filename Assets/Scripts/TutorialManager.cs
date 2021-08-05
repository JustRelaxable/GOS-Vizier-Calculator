using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    int firstRun = 1;
    public GameObject tutorialScreen;
    void Awake()
    {
        firstRun = PlayerPrefs.GetInt("IsFirstRun", 1);

        if(firstRun == 1)
        {
            //Logic
            tutorialScreen.SetActive(true);
            PlayerPrefs.SetInt("IsFirstRun", 0);
        }
        else
        {

        }
    }
    void Update()
    {
        
    }
}
