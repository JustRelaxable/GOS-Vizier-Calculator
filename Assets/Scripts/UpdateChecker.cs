using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;

public class UpdateChecker : MonoBehaviour
{
    public string appVersion;
    public string currentVersion;
    public GameObject updatePanel;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        ConfigManager.FetchCompleted += CheckVersion;
    }

    private void CheckVersion(ConfigResponse obj)
    {
        switch (obj.requestOrigin)
        {
            case ConfigOrigin.Default:
                break;
            case ConfigOrigin.Cached:
                string recordedVersion = PlayerPrefs.GetString("currentVersion");
                if (recordedVersion != "" && appVersion != recordedVersion)
                {
                    updatePanel.SetActive(true);
                }
                break;
            case ConfigOrigin.Remote:
                if(ConfigManager.appConfig.origin == ConfigOrigin.Remote)
                {
                    currentVersion = ConfigManager.appConfig.GetString("app_version");
                    PlayerPrefs.SetString("currentVersion", currentVersion);
                    if(currentVersion != appVersion)
                    {
                        updatePanel.SetActive(true);
                    }
                }
                break;
            default:
                break;
        }
    }
}
