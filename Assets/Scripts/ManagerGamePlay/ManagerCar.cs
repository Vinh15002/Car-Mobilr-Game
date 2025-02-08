
using System;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCar : MonoBehaviour
{
    public static ManagerCar Instance;
    
    public Dictionary<GameObject, int> carMissions;

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
        }
        
    }

    public void CompleteTheLap(GameObject car)
    {
        if (!carMissions.ContainsKey(car)) return;
        int amountLapComplete = carMissions[car];
        amountLapComplete++;
        
        if(amountLapComplete == numberOfLaps)
        {
            Debug.Log(car.name + " : " + "is complete the chanlenger");
        }
        carMissions[car] = amountLapComplete;
    }






}
