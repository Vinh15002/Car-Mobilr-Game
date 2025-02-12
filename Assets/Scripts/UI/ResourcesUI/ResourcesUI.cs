
using System;
using TMPro;
using UnityEngine;


public class ResourcesUI: MonoBehaviour
{
    [SerializeField] private TMP_Text diamond;
    [SerializeField] private TMP_Text coin;



    private void OnEnable()
    {
        ResourceEvent.updateResource += ChangeUI;
    }
    private void OnDisable()
    {
        ResourceEvent.updateResource -= ChangeUI;
    }

    private void ChangeUI(int daimond, int coint)
    {
        diamond.text = daimond.ToString();  
        coin.text = coint.ToString();
    }
}

