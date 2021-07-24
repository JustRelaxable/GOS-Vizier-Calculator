using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChangerButton : MonoBehaviour
{
    public string languageFileName;
    public LanguageChanger languageChanger;

    public void ChangeLanguage()
    {
        languageChanger.ChangeLanguage(languageFileName);
    }
}
