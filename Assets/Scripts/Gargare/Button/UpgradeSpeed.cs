

using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeSpeed:Upgrade
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(UpgradeSpeedCar);
    }

    private void UpgradeSpeedCar()
    {


        ManageGargare.Instance.UpgradeSpeed(this.amount);
    }


    private void OnEnable()
    {
        UpgradeButtonEvent.changeTextSpeed += UpdateUI;
    }

    private void OnDisable()
    {
        UpgradeButtonEvent.changeTextSpeed -= UpdateUI;
    }
}

