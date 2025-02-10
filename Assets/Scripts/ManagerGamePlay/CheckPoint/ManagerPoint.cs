


using System;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPoint : MonoBehaviour
{

    
    public static ManagerPoint Instance;
    private Dictionary<GameObject,CarPointRank> listCar;
    private int amountCheck = 0;



    private void Start()
    {
        Instance = this;
        listCar = new Dictionary<GameObject, CarPointRank>();
        amountCheck = transform.childCount;
        InstaitatePoint();
        
    }

    private void InstaitatePoint()
    {
        for(int i = 0; i < amountCheck; i++)
        {
            transform.GetChild(i).GetComponent<CheckPoint>().indexCheckPoint = i;
        }
    }

    public void SetPassStation(int indexCheckPoint, GameObject gameObject)
    {
       
        listCar[gameObject].setPassCheckPoint(indexCheckPoint);

       
    }

    public void AddCar(GameObject game, int lap)
    {
        
        if (!listCar.ContainsKey(game))
        {
        
            CarPointRank carPointRank = new CarPointRank(lap, amountCheck);
            listCar.Add(game, carPointRank);
        }
    }

    public int CalculateRanking(GameObject game)
    {
        if (!listCar.ContainsKey(game)) return listCar.Count + 1;
        int result = 0;
        CarPointRank currentRank = listCar[game];
        foreach(var item in listCar)
        {
            if(item.Key!= game)
            {
                if (currentRank.CompareRanking(item.Value) == -1) result++;
            }
            

        }
        return result+1;
    }






}



