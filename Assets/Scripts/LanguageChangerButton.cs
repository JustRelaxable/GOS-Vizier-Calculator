using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChangerButton : MonoBehaviour
{
    public string languageFileName;
    public LocalizedTextComponent[] localizedTextComponents;

    public void ChangeLanguage()
    {
        LocalizationManager.instance.fileName = languageFileName;
        LocalizationManager.instance.LoadLocalizationData(languageFileName);

        
        foreach (var item in localizedTextComponents)
        {
            item.Start();
        }

        PlayerPrefs.SetString("selectedLanguage", languageFileName);
    }
}
