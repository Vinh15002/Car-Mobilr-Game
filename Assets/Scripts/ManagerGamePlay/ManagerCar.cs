
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;

public class ManagerCar : MonoBehaviour
{
    public static ManagerCar Instance;

    [HideInInspector] public GameObject mainCar;

    [HideInInspector] public Dictionary<GameObject, int> carMissions;

    [SerializeField] private int numberOfLaps;

    public TMP_Text textLap;





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
        if (car == mainCar)
        {
            textLap.text = amountLapComplete.ToString();
        }

        if (amountLapComplete == numberOfLaps)
        {
            bool ok = car == mainCar;

            ManagerEndGame.Instance.AddCarRank(ok);
            if (!ok)
            {
                mainCar.SetActive(false);
            }
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
