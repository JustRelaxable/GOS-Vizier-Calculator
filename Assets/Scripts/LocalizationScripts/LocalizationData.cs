[System.Serializable]
public class LocalizationData 
{
    public LocalizationItem[] localizationItems;
}

[System.Serializable]
public class LocalizationItem
{
    public string key;
    public string value;
}
