


using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangePresent : MonoBehaviour
{
    public TMP_Text textLoad;
    public Slider slider;
    


    private void OnEnable()
    {
      
        LoadingEvent.changeTextLoading += ChangePresentStatus;
    }

    
    private void OnDisable()
    {
        LoadingEvent.changeTextLoading -= ChangePresentStatus;
    }

    private void ChangePresentStatus(float present)
    {
        textLoad.text = $"{Mathf.CeilToInt(present * 100)}%";
       
        slider.value = present;
        
    }

    
}

