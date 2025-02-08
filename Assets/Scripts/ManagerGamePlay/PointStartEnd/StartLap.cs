using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class StartLap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ManagerCar.Instance.AddCarPremission(other.gameObject);
    }
}

