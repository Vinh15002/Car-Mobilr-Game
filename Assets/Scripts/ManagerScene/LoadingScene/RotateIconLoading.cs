
using UnityEngine;


public class RotateIconLoading:MonoBehaviour
{
    public int rotateSpeed = 1;
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed));
    }
}

