using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour , IUnityAdsListener
{
    public GameObject cardSpawner;
    public static AdManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        Advertisement.Initialize("3427604", false);
        Advertisement.AddListener(this);
    }

    public IEnumerator ShowRewardedAd()
    {
        while (!Advertisement.IsReady("rewardedVideo"))
        {
            yield return new WaitForSeconds(0.1f);
        }
        Advertisement.Show("rewardedVideo");
    }

    public IEnumerator ShowFirstLoadAd()
    {
        while (!Advertisement.IsReady("firstLoad"))
        {
            yield return new WaitForSeconds(0.1f);
        }
        Advertisement.Show("firstLoad");
    }

    public void OnClickRewardedAd()
    {
        StartCoroutine(ShowRewardedAd());
    }

    public void LoadFirstLoadAd()
    {
        StartCoroutine(ShowFirstLoadAd());
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, UnityEngine.Advertisements.ShowResult showResult)
    {
        switch (placementId)
        {
            case "rewardedVideo":
                switch (showResult)
                {
                    case UnityEngine.Advertisements.ShowResult.Failed:
                        break;
                    case UnityEngine.Advertisements.ShowResult.Skipped:
                        break;
                    case UnityEngine.Advertisements.ShowResult.Finished:
                        EfficiencyCard.adWatched = true;
                        cardSpawner = GameObject.FindGameObjectWithTag("EfficiencyCardSpawner");
                        cardSpawner.GetComponent<EfficiencyCardSpawner>().RemoveChilds();
                        cardSpawner.GetComponent<EfficiencyCardSpawner>().GetMyViziers();
                        break;
                    default:
                        break;
                }
                break;
            case "firstLoad":
                break;
            default:
                break;
        }

    }
}
