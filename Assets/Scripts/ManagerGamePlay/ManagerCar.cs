
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class ManagerCar : MonoBehaviour
{
    public static ManagerCar Instance;

    [SerializeField] private GameObject mainCar;

    [HideInInspector] public Dictionary<GameObject, int> carMissions;

    [SerializeField] private int numberOfLaps;





    private void Start()
    {
        carMissions = new Dictionary<GameObject, int>();
        Instance = this;
    }



    public void AddCarPremission(GameObject car)
    {
        if(!carMissions.ContainsKey(car))
        {
            carMissions.Add(car, 0);
            ManagerPoint.Instance.AddCar(car, numberOfLaps);
        }
        
    }

    public void CompleteTheLap(GameObject car)
    {
        if (!carMissions.ContainsKey(car)) return;
        int amountLapComplete = carMissions[car];
        amountLapComplete++;
        
        if(amountLapComplete == numberOfLaps)
        {
            ManagerEndGame.Instance.AddCarRank(car == mainCar);
        }
        carMissions[car] = amountLapComplete;
    }


    public void UpdateRank()
    {
        int pos = ManagerPoint.Instance.CalculateRanking(mainCar);
       
        RankEvent.updateRank?.Invoke(pos);
    }



    public int GetAmountCar()
    {
        return carMissions.Count;
    }

}
