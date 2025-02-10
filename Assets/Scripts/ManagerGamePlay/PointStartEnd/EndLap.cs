

using UnityEngine;

public class EndLap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            ManagerCar.Instance.CompleteTheLap(other.gameObject);
        }
        
    }

}

