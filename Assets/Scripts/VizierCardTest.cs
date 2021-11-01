using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VizierCardTest : MonoBehaviour
{
    public GameObject[] childObjects;
    private bool firstInvisible = true;

    private void Start()
    {
        Visible();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Visible();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Invisible();
    }

    private IEnumerator FirstLoad()
    {
        if (firstInvisible)
        {
            yield return new WaitForSeconds(1f);
            firstInvisible = false;
        }
        else
        {
            Invisible();
        }
    }
}
