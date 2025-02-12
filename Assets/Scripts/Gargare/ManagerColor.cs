using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ManagerColor: MonoBehaviour
{
    public List<GameObject> colorBTNs;
    public static ManagerColor Intance;

    private void Start()
    {
       
        Intance = this;
        AddEventButton();
    }

    private void AddEventButton()
    {
        for(int i = 0; i < colorBTNs.Count; i++)
        {
            int index = i;
            colorBTNs[i].GetComponent<Button>().onClick.AddListener(() => OnClickButton(index));
        }
    }

    private void OnClickButton(int index)
    {
        ManageGargare.Instance.setSkin(index);
    }

    public void SetUpColor(List<SkinCar> skinCar)
    {
        int index = 0;
        for(int i = 0; i < colorBTNs.Count; i++)
        {
            if(index < skinCar.Count)
            {
                colorBTNs[index].SetActive(true);
                colorBTNs[index].GetComponent<Button>().GetComponent<Image>().color = Utils.GetColor(skinCar[index].SkinColor);
            }
            else colorBTNs[index].SetActive(false);
            index++;

        }
    }


   
}

