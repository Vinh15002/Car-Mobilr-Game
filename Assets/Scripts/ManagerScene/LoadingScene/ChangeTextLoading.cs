


using System;
using TMPro;
using UnityEngine;

public class ChangeTextLoading : MonoBehaviour
{
    private TMP_Text textLoad;
    private float timeLoading = 0.02f;

    private void Start()
    {
        textLoad = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        timeLoading-= Time.deltaTime;
    }
    private void OnEnable()
    {
        LoadingEvent.changeTextLoading += ChangeText;
    }
    private void OnDisable()
    {
        LoadingEvent.changeTextLoading -= ChangeText;
    }

    private void ChangeText(float present)
    {
        textLoad.text = "";
        if (timeLoading < 0)
        {
            textLoad.text = $"{Mathf.CeilToInt(present * 100)}%";
            timeLoading = 0.02f;
        }
        
    }
}

