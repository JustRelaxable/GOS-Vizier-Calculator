using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LocalizedTextEditor : EditorWindow
{
    public LocalizationData localizationData;
    public Vector2 scrollPos;

    [MenuItem("Window/Localized Text Editor")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(LocalizedTextEditor)).Show();
    }

    private void OnGUI()
    {
        if(localizationData != null)
        {
            //float scroll = GUILayout.VerticalScrollbar(0f, 1f, 10f, 0f);
            scrollPos = GUILayout.BeginScrollView(scrollPos);
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("localizationData");
            EditorGUILayout.PropertyField(serializedProperty, true);
            GUILayout.EndScrollView();
            serializedObject.ApplyModifiedProperties();
            

            if(GUILayout.Button("Save Data"))
            {
                SaveLocalizationData();
            }
        }

        GUILayout.BeginHorizontal();

        if(GUILayout.Button("Load Localized JSON"))
        {
            LoadLocalizationData();
        }

        if(GUILayout.Button("Create New Localize Data"))
        {
            CreateNewData();
        }

        GUILayout.EndHorizontal();
    }

    public void LoadLocalizationData()
    {
        string path = EditorUtility.OpenFilePanel("Load Your Localization Data", Application.streamingAssetsPath, "json");

        if (File.Exists(path))
        {
            string textAsJson = File.ReadAllText(path);
            localizationData = JsonUtility.FromJson<LocalizationData>(textAsJson);
        }
    }
    private void SaveLocalizationData()
    {
        string path = EditorUtility.SaveFilePanel("Save Your Localization Data", Application.streamingAssetsPath, "", "json");

        if (!string.IsNullOrEmpty(path))
        {
            string jsonData = JsonUtility.ToJson(localizationData);
            File.WriteAllText(path, jsonData);
        }
    }

    private void CreateNewData()
    {
        localizationData = new LocalizationData();
    }
}
