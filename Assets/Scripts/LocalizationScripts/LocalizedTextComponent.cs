using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizedTextComponent : MonoBehaviour
{
    private Text textToModify;
    public string key;

    private void Awake()
    {
        textToModify = GetComponent<Text>();
    }

    public void Start()
    {
        textToModify.text = LocalizationManager.instance.localizationDictionary[key];
    }
}
