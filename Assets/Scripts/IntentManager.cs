using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using UnityEngine.Networking;
using Unity.RemoteConfig;

public class IntentManager : MonoBehaviour
{
    public static IntentManager instance;
    public string youtubeLink;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log(ConfigManager.requestStatus);
        ConfigManager.FetchCompleted += GetYoutubeLink; 
        ConfigManager.FetchConfigs(new UserAttributes(), new AppAttributes());
    }

    private void GetYoutubeLink(ConfigResponse response)
    {
        switch (response.requestOrigin)
        {
            case ConfigOrigin.Default:
                break;
            case ConfigOrigin.Cached:
                break;
            case ConfigOrigin.Remote:
                Debug.Log(ConfigManager.requestStatus);
                string[] keys =  ConfigManager.appConfig.GetKeys();
                youtubeLink = ConfigManager.appConfig.GetString("youtube_link", defaultValue: "Unknown Exception, Please mail to 'tahasokmen222@gmail.com' ");
                break;
            default:
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationFocus(bool focused)
    {
        if (focused)
        {
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intent = currentActivity.Call<AndroidJavaObject>("getIntent");
            AndroidJavaObject uri = intent.Call<AndroidJavaObject>("getData");
            
            AndroidJavaObject inputStreamObj = currentActivity.Call<AndroidJavaObject>("getContentResolver").Call<AndroidJavaObject>("openInputStream",uri);
            AndroidJavaObject unityAndroidStream = new AndroidJavaObject("com.Rc2.GOSVizierCalculate.UnityAndroidStream", inputStreamObj);
            //AndroidJavaClass ioUtils= new AndroidJavaClass("org.apache.commons.io.IOUtils");
            //string textAsBinary = ioUtils.CallStatic<string>("toString", inputStreamObj, "UTF-8");
            

            //AndroidJavaObject file = new AndroidJavaObject("java.io.File", uri.Call<string>("getPath"));
            //string path = uri.Call<string>("getPath");

            //UnityWebRequest www = UnityWebRequest.Get(path);
            //www.SendWebRequest();

            //while (!www.isDone)
            {
            }

            //string textAsBinary = www.downloadHandler.text;
            try
            {
                CustomStream customStream = new CustomStream(unityAndroidStream);

                //StreamReader reader = new StreamReader(customStream);
                //string textAsBinary = reader.ReadToEnd();
                //MemoryStream mStrm = new MemoryStream(Encoding.UTF8.GetBytes(textAsBinary));
                MemoryStream ms = new MemoryStream();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                ShareClass shareClass = binaryFormatter.Deserialize(customStream) as ShareClass;
                SharedViziersLister.incomingViziers = shareClass;
                SceneManager.LoadScene("sharedLister");
            }
            catch (System.Exception e)
            {

                Debug.Log(e.Message);
            }
        }
    }

    public void ShareViziers()
    {
        List<VizierCardDataContainer> myviziers = MyVizierList.myViziers;
        if(myviziers.Count > 0)
        {
            ShareClass dataToSerialize = new ShareClass();
            dataToSerialize.additionalInformation = "Denemgrgrgegregegergregergegergegergeergergege";
            dataToSerialize.vizierList = myviziers;

            FileStream vizierFile = null;
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                vizierFile = File.Create(Application.persistentDataPath + "/SharedViziers.vzr");
                binaryFormatter.Serialize(vizierFile, dataToSerialize);   
            }

            catch(System.Exception e)
            {
                Debug.Log(e);
            }
            finally
            {
                if (vizierFile != null)
                {
                    vizierFile.Close();
                }
                AndroidCreateIntentAndChooser();
            }
        }
    }

    public void AndroidCreateIntentAndChooser()
    {
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent");
        intent.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        intent.Call<AndroidJavaObject>("setType", "text/plain");

        AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject uri;

        AndroidJavaClass jc = new AndroidJavaClass("android.os.Environment");
        string path = jc.CallStatic<AndroidJavaObject>("getExternalStorageDirectory").Call<string>("getAbsolutePath");

        AndroidJavaObject file = new AndroidJavaObject("java.io.File", (Application.persistentDataPath + "/SharedViziers.vzr"));

        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaClass fileProvider = new AndroidJavaClass("androidx.core.content.FileProvider");
        uri = fileProvider.CallStatic<AndroidJavaObject>("getUriForFile", currentActivity, currentActivity.Call<AndroidJavaObject>("getApplicationContext").Call<string>("getPackageName") + ".provider", file);
        //uri = uriClass.CallStatic<AndroidJavaObject>("fromFile", file);

        intent.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uri);

        AndroidJavaClass clipDataClass = new AndroidJavaClass("android.content.ClipData");
        AndroidJavaObject clipData = clipDataClass.CallStatic<AndroidJavaObject>("newPlainText", "Youtube Page", youtubeLink);
        AndroidJavaObject clipBoardManagerObject = currentActivity.Call<AndroidJavaObject>("getSystemService", "clipboard");
        AndroidJavaObject clipBoardManager = Cast(clipBoardManagerObject, "android.content.ClipboardManager");
        clipBoardManager.Call("setPrimaryClip", clipData);

        AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intent, "Share Your Viziers With Friends");
        currentActivity.Call("startActivity", chooser);
    }

    public AndroidJavaObject ClassForName(string className)
    {
        using (var clazz = new AndroidJavaClass("java.lang.Class"))
        {
            return clazz.CallStatic<AndroidJavaObject>("forName", className);
        }
    }

    public AndroidJavaObject Cast(AndroidJavaObject source, string destClass)
    {
        using (var destClassAJC = ClassForName(destClass))
        {
            return destClassAJC.Call<AndroidJavaObject>("cast", source);
        }
    }
}

public struct UserAttributes
{
    // Optionally declare variables for any custom user attributes:
    public bool expansionFlag;
}

public struct AppAttributes
{
    // Optionally declare variables for any custom app attributes:
    public int level;
    public int score;
    public string appVersion;
}

