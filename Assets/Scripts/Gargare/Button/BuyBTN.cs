using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BuyBTN : MonoBehaviour
{
    public TMP_Text text;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnBuyItem);
    }

    private void OnBuyItem()
    {
        ManageGargare.Instance.BuyItem(int.Parse(text.text));
    }
}

