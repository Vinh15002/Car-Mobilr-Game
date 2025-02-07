using Assets.Scripts.CarAIEnemy.CarOpponent;
using Assets.Scripts.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Event.WaypointCarEvent;

public class OpponentCar : MonoBehaviour
{
    [Header("Car Engine")]
    [SerializeField] private float maxSpeed;
   
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float turingSpeed = 30f;
    [SerializeField] private float breackSpeed = 12f;

    public float currentSpeed = 10f;


    [Header("Destionation Var")]
    [HideInInspector] public Vector3 destionation;
    [HideInInspector] public bool destinationReached;

    private Rigidbody rb;


    private OpponentCarWaypoints waypointCar;
    private ResetDestenition resetDestenition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        waypointCar = transform.GetComponent<OpponentCarWaypoints>();
        resetDestenition  = GetComponent<ResetDestenition>();
        rb.useGravity = true;
    }

   
    private void FixedUpdate()
    {
        rb.AddForce(-transform.up * 10000);
        Drive();
        
       
    }

    public void Drive()
    {
        if(!destinationReached)
        {
            Vector3 direction = destionation - transform.position;
            //direction.y = 0;
            float distance = direction.magnitude;
            if(distance >= breackSpeed)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turingSpeed * Time.deltaTime);

                float angle = Vector3.Angle(transform.forward, direction);

                currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, Time.deltaTime);
                ApplyBrackePower(angle);
                rb.velocity = transform.forward * currentSpeed;
            }
            else
            {
                
                destinationReached = true;
                waypointCar.ChangeDestination();
                resetDestenition.SetNewDestination();


            }
        }
    }

    public void LocateDestionation(Vector3 destionation)
    {
        this.destionation = destionation;
        destinationReached = false;
    }


    public void ApplyBrackePower(float angle)
    {
        float redu = Random.Range(0f, acceleration);
        currentSpeed -= angle/180* redu;
        currentSpeed = currentSpeed >= 0 ? currentSpeed : 0;
    }

   

}
