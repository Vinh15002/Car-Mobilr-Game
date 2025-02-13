using Assets.Scripts.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Car.GUIControl.RightGroupButton
{
    public class RightGroupBTN: MonoBehaviour
    {
        [SerializeField] private GameObject car;
        private GameObject BuffSpeedBTN;
        private ButtonPressEvent DriftBTN;
        private ButtonPressEvent DirectionBTN;
        

        private CarController carControl;
        private BuffSpeed buffSpeed;
        private bool isFullPower = false;

        private void Start()
        {
            BuffSpeedBTN = transform.Find("BuffSpeed").gameObject;
            DriftBTN = transform.Find("DriftCar").GetComponent<ButtonPressEvent>();
            DirectionBTN = transform.Find("ReverseDirection").GetComponent<ButtonPressEvent>();

           
            BuffSpeedBTN.GetComponent<Button>().onClick.AddListener(ProcessBuffSpeedBTN);
            DriftBTN.eventPressBTN += DriftCarEvent;
            DriftBTN.eventReleaseBTN += NoDriftEvent;
            DirectionBTN.eventPressBTN += DirectionTowardEvent;
            DirectionBTN.eventReleaseBTN += DirectionBackwardEvent;
           



        }

        

        private void FixedUpdate()
        {
            ChangeStatusBuffSpeed();
        }

        private void OnEnable()
        {
            PowerCarEvent.powerFull += ChangeStatus;
            ChangeTargetEvent.setTarGetCar += SetData;
        }

        private void SetData(GameObject car)
        {
            this.car = car;
            carControl = car.GetComponent<CarController>();
            buffSpeed = car.GetComponentInChildren<BuffSpeed>();
        }

        private void ChangeStatus(bool status)
        {
       
            isFullPower = status;
        }

        private void OnDisable()
        {
            DriftBTN.eventPressBTN -= DriftCarEvent;
            DriftBTN.eventReleaseBTN -= NoDriftEvent;
        }


        private void ChangeStatusBuffSpeed()
        {
            if (isFullPower)
            {
                BuffSpeedBTN.transform.Rotate(new Vector3(0, 0, -30f));
            }
            else
            {
                BuffSpeedBTN.transform.rotation = Quaternion.identity;
            }
        }


        private void ProcessBuffSpeedBTN()
        {
            
            buffSpeed.BuffSpeedCar();
        }

        private void DriftCarEvent()
        {
            carControl.handBrake = true;
        }

        private void NoDriftEvent()
        {
            carControl.handBrake = false;
        }

        private void DirectionBackwardEvent()
        {
            carControl.vertical = 1;
        }

        private void DirectionTowardEvent()
        {
            carControl.vertical = -1;
        }


     



    }
}
