using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VizierCardOptimizer : MonoBehaviour
{
    [SerializeField]
    RectTransform rectTransform;

    public GameObject[] childObjects;

    [SerializeField]
    private Camera camera;
    [SerializeField]
    private ScrollRect scrollRect;

    private const float DistanceToRecalcVisibility = 400.0f;
    private const float DistanceMarginForLoad = 600.0f;
    private float lastPos = Mathf.Infinity;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Start()
    {
        this.scrollRect.onValueChanged.AddListener((newValue) => {
            if (Mathf.Abs(this.lastPos - this.scrollRect.content.transform.localPosition.y) >= DistanceToRecalcVisibility)
            {
                lastPos = this.scrollRect.content.transform.localPosition.y;

                Vector2 scrollRectPosition = RectTransformUtility.WorldToScreenPoint(this.camera, this.scrollRect.transform.position);
                RectTransform scrollRectTransform = this.scrollRect.GetComponent<RectTransform>();
                float checkRectMinY = scrollRectPosition.y + scrollRectTransform.rect.yMin - DistanceMarginForLoad;
                float checkRectMaxY = scrollRectPosition.y + scrollRectTransform.rect.yMax + DistanceMarginForLoad;

                foreach (Transform child in this.scrollRect.content)
                {
                    Vector2 childPosition = RectTransformUtility.WorldToScreenPoint(this.camera, child.position);
                    // uncomment lines bellow if you set DistanceMarginForLoad less than height of single element
                    //RectTransform childRectTransform = child.GetComponent<RectTransform>();
                    //float childMinY = childPosition.y + childRectTransform.rect.yMin;
                    //float childMaxY = childPosition.y + childRectTransform.rect.yMax;
                    //if (childMaxY >= checkRectMinY && childMinY <= checkRectMaxY) {

                    if (childPosition.y >= checkRectMinY && childPosition.y <= checkRectMaxY)
                    {
                        child.gameObject.SetActive(false);
                    }
                    else
                    {
                        child.gameObject.SetActive(true);
                    }
                }
            }
        });
    }

    private void Invisible()
    {
        for (int i = 0; i < childObjects.Length; i++)
        {
            childObjects[i].SetActive(false);
        }
    }

    private void Visible()
    {
        for (int i = 0; i < childObjects.Length; i++)
        {
            childObjects[i].SetActive(true);
        }
    }

    private IEnumerator AmIVisible()
    {
        while (true)
        {
            if (rectTransform.IsVisibleFrom(Camera.main))
            {
                Visible();
            }
            else
            {
                Invisible();
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
