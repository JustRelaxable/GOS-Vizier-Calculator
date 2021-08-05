using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        loadingScreen.SetActive(true);

        while (asyncOperation.progress < 0.9f)
        {
            yield return new WaitForSeconds(0.1f);
        }

        asyncOperation.allowSceneActivation = true;
    }

    public void OpenDeveloperPage()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=6698319416173786698");
    }

    public void SendTranslationEmail()
    {
        string email = "rc2std@gmail.com";
        string subject = MyEscapeURL("About Translation of GoS Vizier Calculator Application");
        string body = MyEscapeURL("Please write the language you want to translate. I will contact with you as soon as possible");
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }
    string MyEscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }
}
