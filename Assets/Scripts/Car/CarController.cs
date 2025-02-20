using Assets.Scripts.Car;
using Assets.Scripts.Event;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public enum CarType
    {
        FrontWheelDrive,
        RearWheelDrive,
        FourWheelDrive
    };

    public CarType carType = CarType.FourWheelDrive;

    

    public ControlMode controlMode;

    [Header("SIDESTFFESSS")]
    public float begin = 2f;
    public float endBrack = 2.4f;
    


    [Header("Wheel GameObject Meshs")]
    public GameObject FrontWL;
    public GameObject FrontWR;
    public GameObject BackWL;
    public GameObject BackWR;


    [Header("WheelColiders")]
    public WheelCollider FrontWLColider;
    public WheelCollider FrontWRColider;
    public WheelCollider BackWLColider;
    public WheelCollider BackWRColider;

    
   
    [Header("Movement, Steering, Bracking")]
    public float maximunMotoTorque; //Mo men xoan dong co toi da 
    public float maximumSteeringAngle = 20f; //Goc dieu khien toi da
    public float maximumSpeed;
    public float brackePower;
    public Transform COM;


    float carSpeed;
    float carSpeedConverted;
    float MotorTorque; // Mo mem xoan dong co
    float tireAngle;
    public float vertical = 1;
    [HideInInspector] public float horizontal = 0;
    [HideInInspector] public bool handBrake = false;
    [HideInInspector] public Rigidbody carRigidbody;
   

    [Header("Sound & Effects")]
    [SerializeField] private CarSmokeEffect smokeEffect;
    [SerializeField] private CarTrailEffect trailEffect;

    private void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();

        if (carRigidbody != null)
        {
            carRigidbody.centerOfMass = COM.localPosition;
        }
        


    }

    private void Update()
    {

        carRigidbody.AddForce(-transform.up * carSpeed * 100);
        GetInputs();
        CalculateSteering();
        CalculateCarMovement();
        
        
        BuffSpeed();

        ApplyTransfromToWheels();
    }
    void GetInputs()
    {
        if(controlMode == ControlMode.Keyboard)
        {
            horizontal = Input.GetAxis("Horizontal");

            vertical = Input.GetAxis("Vertical");
            if (Input.GetKey(KeyCode.Space)) handBrake = true;
            else handBrake = false;

            
        }
    }


    

    void CalculateCarMovement()
    {
        carSpeed = carRigidbody.velocity.magnitude;
        carSpeedConverted = Mathf.Round(carSpeed * 3.6f);
        SpeedCarEvent.speedCarUI?.Invoke(carSpeedConverted, maximumSpeed);
        ApplyMotorTorque();
        handleDripting();

        //Voulum 
        if(ManagerSound.Instance != null)
        {
            ManagerSound.Instance.AddSoundCar(carSpeedConverted);
        }
        




    }

   

    private void CalculateSteering()
    {
       
        tireAngle = maximumSteeringAngle * horizontal;
        FrontWLColider.steerAngle = tireAngle;
        FrontWRColider.steerAngle = tireAngle;
    }


    

    private void ApplyMotorTorque()
    {
        if(carType == CarType.FrontWheelDrive)
        {
            FrontWLColider.motorTorque = MotorTorque;
            FrontWRColider.motorTorque = MotorTorque;

        }
        else if (carType == CarType.RearWheelDrive)
        {
            BackWLColider.motorTorque = MotorTorque;
            BackWRColider.motorTorque = MotorTorque;
        }
        else if (carType == CarType.FourWheelDrive)
        {
            FrontWLColider.motorTorque = MotorTorque;
            FrontWRColider.motorTorque = MotorTorque;
            BackWLColider.motorTorque = MotorTorque;
            BackWRColider.motorTorque = MotorTorque;
        }
    }

    private void handleDripting()
    {
        if (handBrake)
        {
            ApplyBrake();
            smokeEffect.setEnableSmokeEffect(true);
            trailEffect.SetTrailEnable(true);
            ManagerSound.Instance.TurnOnDrift();
        }
        else
        {
            ReleaseBrake(); 
            if (carSpeedConverted < maximumSpeed)
                MotorTorque = maximunMotoTorque * vertical;
            else
                MotorTorque = 0;
            smokeEffect.setEnableSmokeEffect(false);
            trailEffect.SetTrailEnable(false);
            ManagerSound.Instance.TurnOffDrift();
        }
    }

    private void ApplyBrake()
    {
        tireAngle = 20 * horizontal;
        FrontWLColider.steerAngle = tireAngle;
        FrontWRColider.steerAngle = tireAngle;

        WheelFrictionCurve customCurve = new WheelFrictionCurve();
        customCurve.extremumSlip = 0.2f; ;
        customCurve.extremumValue = 1f;
        customCurve.asymptoteSlip = 0.5f;
        customCurve.asymptoteValue = 0.5f;
        customCurve.stiffness = endBrack;
        BackWLColider.sidewaysFriction = customCurve;
        BackWRColider.sidewaysFriction = customCurve;

        FrontWLColider.brakeTorque = brackePower * Mathf.Pow(carSpeed, 5); 
        FrontWRColider.brakeTorque = brackePower * Mathf.Pow(carSpeed, 5);
        BackWLColider.brakeTorque = brackePower * Mathf.Pow(carSpeed, 5);
        BackWLColider.brakeTorque = brackePower * Mathf.Pow(carSpeed, 5);

        PowerCarEvent.addPower(Time.deltaTime * 50);
    }

    private void ReleaseBrake()
    {
        FrontWLColider.brakeTorque = 0;
        FrontWRColider.brakeTorque = 0;
        BackWLColider.brakeTorque = 0;
        BackWLColider.brakeTorque = 0;

        WheelFrictionCurve customCurve = new WheelFrictionCurve();
        customCurve.extremumSlip = 0.2f;
        customCurve.extremumValue = 1f;
        customCurve.asymptoteSlip = 0.75f;
        customCurve.asymptoteValue = 0.5f;
        customCurve.stiffness = begin;
        BackWLColider.sidewaysFriction = customCurve;
        BackWRColider.sidewaysFriction = customCurve;

    }


    public void ApplyTransfromToWheels()
    {
        Vector3 position;
        Quaternion rotation;

        FrontWLColider.GetWorldPose(out position, out rotation);
        ApplyWheel(FrontWL, position, rotation);

        FrontWRColider.GetWorldPose(out position, out rotation);
        ApplyWheel(FrontWR, position, rotation);

        BackWLColider.GetWorldPose(out position, out rotation);
        ApplyWheel(BackWL, position, rotation);

        BackWRColider.GetWorldPose(out position, out rotation);
        ApplyWheel(BackWR, position, rotation);

    }

    public void ApplyWheel(GameObject wheel, Vector3 position, Quaternion rotation)
    {
        wheel.transform.position = position;
        wheel.transform.rotation = rotation;
    }

    public void BuffSpeed()
    {
        if (Input.GetKey(KeyCode.M))
        {
            BackWLColider.motorTorque = MotorTorque + 1500;
            BackWRColider.motorTorque = MotorTorque+ 1500;
        }
    }
    

}
