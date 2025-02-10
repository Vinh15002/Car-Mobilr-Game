
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;


public class ManagerEndGame : MonoBehaviour
{

    public GameObject positonRank;
    public GameObject rankCar;
    public GameObject UI;
    public static ManagerEndGame Instance;

    private int currentPos = 0;

    private List<FinishData> nameCar;

    private void Start()
    {
        Instance = this;
        nameCar = new List<FinishData>();
    }


    public void AddCarRank(bool isMainCar)
    {
        if(!isMainCar) {

            AddCarAIComplete();
        }
        else
        {
            UI.SetActive(true);

            AddMainCarComplete();


            while (currentPos < ManagerCar.Instance.GetAmountCar())
            {
                currentPos++;
                AddCarUnComplete();
                
            }
            AddUI();
        }

       
        
        
    }

    private void AddUI()
    {
        foreach(var item in nameCar)
        {
            AddPositionCar(item);
        }
    }

    private void AddCarAIComplete()
    {
        currentPos++;
        string name = RandomName.GetRandomName();
        FinishData data = new FinishData(currentPos.ToString(), name, TimeGamePlay.Instance.ConvertTime());
        nameCar.Add(data);
    }

    private void AddCarUnComplete()
    {
        
        string name = RandomName.GetRandomName();
        FinishData data = new FinishData(currentPos.ToString(), name, "...");
        nameCar.Add(data);
    }
    private void AddMainCarComplete()
    {
        currentPos++;
        
        FinishData data = new FinishData(currentPos.ToString(), "You", TimeGamePlay.Instance.ConvertTime());
        nameCar.Add(data);
    }
   
    public void AddPositionCar(FinishData data)
    {
      
        string pos = data.pos + "ST";
        string time = data.time;
        string name = data.name;
        
        GameObject game = Instantiate(positonRank, rankCar.transform);
        game.GetComponent<Position>().SetContent(pos, name, time);
    }






}

