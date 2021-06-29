using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour , IUnityAdsListener
{
    public GameObject cardSpawner;
    private void Awake()
    {
        Advertisement.Initialize("3427604", false);
        Advertisement.AddListener(this);
    }

    public IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.IsReady("rewardedVideo"))
        {
            yield return new WaitForSeconds(0.1f);
        }
        Advertisement.Show("rewardedVideo");
    }

    public void OnClick()
    {
        StartCoroutine(ShowAdWhenReady());
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
    }
}
