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

        [SerializeField] private CarController car;

        
        private float valueSteering = 0;

        public float speedSteering = 1f;

        private bool isPressButton = false;


        public void Update()
        {
            HandleDrive();
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
            Debug.Log("Left");
            valueSteering = -1f;
            isPressButton = true;
            //valueSteering = valueSteering > -speedSteering ? valueSteering : -speedSteering;
        }

        public void OnRightDownButton()
        {
            Debug.Log("Right");
            valueSteering = 1f;
            isPressButton = true;
            //valueSteering = valueSteering < speedSteering ? valueSteering : speedSteering;
        }

        




        public void OnButtonUp()
        {
            isPressButton = false;
        }
















    }
}
