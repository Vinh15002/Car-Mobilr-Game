using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class CheckPoint: MonoBehaviour
{
    public int indexCheckPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            ManagerPoint.Instance.SetPassStation(indexCheckPoint, other.gameObject);
            ManagerCar.Instance.UpdateRank();
        }
    }
}

