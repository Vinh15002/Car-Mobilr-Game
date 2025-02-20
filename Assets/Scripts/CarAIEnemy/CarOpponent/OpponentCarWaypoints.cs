using Assets.Scripts.CarAIEnemy;
using Assets.Scripts.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCarWaypoints : MonoBehaviour
{
    [Header("Opponent Car")]
    public OpponentCar car;
    public WayPoint currentWaypoint;
    private void Start()
    {
        car.LocateDestionation(currentWaypoint.GetPosition());
    }
    public void ChangeDestination()
    {
        currentWaypoint = currentWaypoint.nextWayPoint;
        car.LocateDestionation(currentWaypoint.GetPosition());
    }
    public void SetResetDestenitation()
    {
        transform.position = currentWaypoint.GetPosition();

        ChangeDestination();
        car.currentSpeed = 7f;


    }

}
