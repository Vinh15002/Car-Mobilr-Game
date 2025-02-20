
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManagerEndGame : MonoBehaviour
{

    public GameObject positonRank;
    public GameObject rankCar;
    public GameObject UI;
    public static ManagerEndGame Instance;

    public List<GameObject> UIEndGameOff;

    private int currentPos = 0;

    private List<FinishData> nameCar;

    public Button back;




    private void Start()
    {
        Instance = this;
        nameCar = new List<FinishData>();
        back.onClick.AddListener(BackScene);
    }

    private void BackScene()
    {
        ManagerScene.Instance.ChangeSceneNoLoading(StringScene.AreaScene);
    }

    public void AddCarRank(bool isMainCar)
    {
        if(!isMainCar) {

            AddCarAIComplete();
        }
        else
        {
            UI.SetActive(true);
            foreach(var item in UIEndGameOff)
            {
                item.SetActive(false);
            }
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
        string name;
        name = "YOU";
        if (ManagerAccount.Instance != null)
        {
            name = ManagerAccount.Instance.MainAccout.name;
        }
        
        FinishData data = new FinishData(currentPos.ToString(), name, TimeGamePlay.Instance.ConvertTime());
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

