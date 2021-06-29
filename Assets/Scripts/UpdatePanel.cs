using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePanel : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {

    }
}
