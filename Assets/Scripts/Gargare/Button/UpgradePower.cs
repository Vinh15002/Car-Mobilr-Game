


using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePower: Upgrade
{

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(UpgradePowerCar);
    }

    private void UpgradePowerCar()
    {


        ManageGargare.Instance.UpgradePower(this.amount);
    }

    private void OnEnable()
    {
        UpgradeButtonEvent.changeTextPower += UpdateUI;
    }

    

    private void OnDisable()
    {
        UpgradeButtonEvent.changeTextPower -= UpdateUI;
    }


}

