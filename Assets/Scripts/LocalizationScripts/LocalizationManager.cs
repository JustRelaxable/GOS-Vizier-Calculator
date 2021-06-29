
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour
{
    public Dictionary<string, string> localizationDictionary;
    public static LocalizationManager instance;
    public string fileName;
    public bool IsReady = false;
    

    private void Awake()
    {
        SetAppLanguage();
        if(instance != null)
        {
            Destroy(this.gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        LoadLocalizationData(fileName);
    }

    private void Start()
    {
        
    }
    public void LoadLocalizationData(string filePath)
    {
        localizationDictionary = new Dictionary<string, string>();
        string fullPath = Path.Combine(Application.streamingAssetsPath, filePath);
        UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(fullPath);
        www.SendWebRequest();

        while (!www.isDone)
        {
        }

        string textAsJson = www.downloadHandler.text;
        LocalizationData localizationData = JsonUtility.FromJson<LocalizationData>(textAsJson);
        for (int i = 0; i < localizationData.localizationItems.Length; i++)
        {
            localizationDictionary.Add(localizationData.localizationItems[i].key, localizationData.localizationItems[i].value);
        }
        IsReady = true;
    }

    public void SetAppLanguage()
    {
        if(PlayerPrefs.GetString("selectedLanguage") == "")
        {
            AndroidJavaClass localeClass = new AndroidJavaClass("java.util.Locale");
            string currentLanguage = localeClass.CallStatic<AndroidJavaObject>("getDefault").Call<string>("getLanguage");

            switch (currentLanguage)
            {
                case "ru":
                    fileName = "localization_ru.json";
                    break;
                case "tr":
                    fileName = "localization_tr.json";
                    break;
                case "en":
                    fileName = "localization_en.json";
                    break;
                case "it":
                    fileName = "localization_it.json";
                    break;
                case "fr":
                    fileName = "localization_fr.json";
                    break;
                case "ur":
                    fileName = "localization_pk.json";
                    break;
                default:
                    break;
            }
        }

        else
        {
            fileName = PlayerPrefs.GetString("selectedLanguage");
        }
    }
}
