using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Car.GUIControl
{
    public class CarDriveGUI : MonoBehaviour
    {

        private CarController car;

        
        private float valueSteering = 0;

        public float speedSteering = 1f;

        private bool isPressButton = false;


        private void OnEnable()
        {
            ChangeTargetEvent.setTarGetCar += SetData;
        }
        public void Update()
        {
            HandleDrive();
        }

        private void OnDisable()
        {
            ChangeTargetEvent.setTarGetCar -= SetData;
        }

        private void SetData(GameObject car)
        {
            this.car = car.GetComponent<CarController>();
        }

        



        private void HandleDrive()
        {
            if(isPressButton)
            {
                car.horizontal = valueSteering;
            }else
            {
                car.horizontal = 0;
            }
           

            
        }
        public void OnLeftDownButton()
        {
            
            valueSteering = -1f;
            isPressButton = true;
            
        }

        public void OnRightDownButton()
        {
           
            valueSteering = 1f;
            isPressButton = true;
        }

        




        public void OnButtonUp()
        {
            isPressButton = false;
        }
















    }
}
