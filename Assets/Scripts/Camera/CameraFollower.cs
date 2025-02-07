using Assets.Scripts.Car;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private float moveSmoothness;
    [SerializeField] private float rotationSmoothness;

    [SerializeField] private Vector3 moveOffset;
    [SerializeField] private Vector3 rotationOffset;

    [SerializeField] private Transform carTarget;
    [SerializeField] private float desiredFOV = 80f;

    

    private float defaultFOV;
    private float currentFOV;

    

    









    private void Start()
    {
        defaultFOV = GetComponent<Camera>().fieldOfView;
        
    }


    private void LateUpdate()
    {
        FollowTarget();   
    }


    void FollowTarget()
    {
        HangleCarMovement();
        HandleRotation();
    }
    
   

    void HandleRotation()
    {
        Vector3 direction = carTarget.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction + rotationOffset, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, moveSmoothness * Time.deltaTime);
    }

    private void HangleCarMovement()
    {
        
        HandlePositon(moveOffset);
       
    }

    private void HandlePositon(Vector3 offset)
    {
        Vector3 targetPos = carTarget.TransformPoint(offset);

        transform.position = Vector3.Lerp(transform.position, targetPos, moveSmoothness * Time.deltaTime);

    }




    public void EnableBoostCar()
    {
        currentFOV = GetComponent<Camera>().fieldOfView;
        GetComponent<Camera>().fieldOfView = Mathf.Lerp(currentFOV, desiredFOV, Time.deltaTime*5f);
      
        
    }

    public void DisableBoostCar()
    {
        currentFOV = GetComponent<Camera>().fieldOfView;
        GetComponent<Camera>().fieldOfView = Mathf.Lerp(currentFOV, defaultFOV, Time.deltaTime * 2f);
    }




}
