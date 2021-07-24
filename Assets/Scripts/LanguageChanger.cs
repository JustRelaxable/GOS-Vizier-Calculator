using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LanguageChanger : MonoBehaviour
{
    public LocalizedTextComponent[] localizedTextComponents;

    public void ChangeLanguage(string languageFileName)
    {
        LocalizationManager.instance.fileName = languageFileName;
        LocalizationManager.instance.LoadLocalizationData(languageFileName);


        foreach (var item in localizedTextComponents)
        {
            item.Start();
        }

        PlayerPrefs.SetString("selectedLanguage", languageFileName);
    }

    void Start()
    {
    }

    void Update()
    {
        
    }
}
