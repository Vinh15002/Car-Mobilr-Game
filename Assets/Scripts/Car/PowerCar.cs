using Assets.Scripts.Event;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Car
{
    public class PowerCar: MonoBehaviour
    {
        public float maxPower = 100f;
        public float currentPower = 0;




        private void OnEnable()
        {
            PowerCarEvent.addPower += AddPowerByBrakeCar;
            
        }

        private void OnDisable()
        {
            PowerCarEvent.addPower -= AddPowerByBrakeCar;
           
        }


        private void FixedUpdate()
        {
            AddPowerByTime();
            PowerCarEvent.getPresentPower?.Invoke(getPresent());
        }
        private void AddPowerByBrakeCar(float amount)
        {
            AddPower(amount);
        }

        public CarBuffEffect getBuffEffect()
        {
            CarBuffEffect carBuffEffect = new CarBuffEffect();
            if(currentPower < 50)
            {
                carBuffEffect = CarBuffEffect.None;
                
            }
            else if (currentPower <99)
            {
                carBuffEffect = CarBuffEffect.TypeBuff01;
                
            }
            else
            {
                carBuffEffect = CarBuffEffect.TypeBuff02;
              

            }
            return carBuffEffect;
        }


        private void AddPower(float amount)
        {
            currentPower += amount;
            currentPower = currentPower <= maxPower ? currentPower : maxPower;
            PowerCarEvent.powerFull?.Invoke(currentPower == maxPower);
        }


        private void MinusPower(float amount)
        {
            currentPower -= amount;
            currentPower = currentPower >= 0 ? currentPower : maxPower;
            
        }



        public void UsingPower(CarBuffEffect typeBuff)
        {

            if(typeBuff == CarBuffEffect.TypeBuff01)
            {
                currentPower -= 50;
            }
            else
            {
                currentPower = 0;
            }
        }

        private void AddPowerByTime()
        {
            AddPower(Time.deltaTime*5);
        }

        public float getPresent()
        {
            return currentPower/maxPower;
        }


    }
}
