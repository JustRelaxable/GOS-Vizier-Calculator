using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VizierLoader : MonoBehaviour
{
    [SerializeField]
    public static VizierCardDataContainer selectedVizier;
    public static sceneFrom from;

    public void ReturnVizierList()
    {
        switch (from)
        {
            case sceneFrom.sharedViziers:
                SceneManager.LoadSceneAsync("sharedLister");
                break;
            default:
                SceneManager.LoadSceneAsync("ListViziersNewVersion");
                break;
        }       
    }
}

public enum sceneFrom
{
    myViziers,
    sharedViziers
}
