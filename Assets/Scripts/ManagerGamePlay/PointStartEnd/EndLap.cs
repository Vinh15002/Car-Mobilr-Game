

using UnityEngine;

public class EndLap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ManagerCar.Instance.CompleteTheLap(other.gameObject);
    }

}

