

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBTN:MonoBehaviour
{
    public GameObject SelectBTN;
    public GameObject BuyBTN;

    public GameObject groupUpgradeBTN;



    private void Start()
    {
        SelectBTN.GetComponent<Button>().onClick.AddListener(OnSelectButton);
        
    }

   

    private void OnSelectButton()
    {
        ManageGargare.Instance.SelectCar();
    }

    public void SetSelectBTN()
    {
        SelectBTN.SetActive(true);
        BuyBTN.SetActive(false);
        groupUpgradeBTN.SetActive(true);
    }
    public void SetBuyBTN()
    {
        SelectBTN.SetActive(false);
        BuyBTN.SetActive(true);
        groupUpgradeBTN.SetActive(false);

    }
    public void SetGroupBTN()
    {
        SelectBTN.SetActive(false);
        BuyBTN.SetActive(false);
        groupUpgradeBTN.SetActive(true);
    }

    public void setPriceBuyBTN(int amount)
    {
        if (!BuyBTN.activeSelf) return;
        BuyBTN.transform.GetChild(1).GetComponent<TMP_Text>().text = amount.ToString();
    }


}

