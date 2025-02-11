using Assets.Scripts.Car.Effect;
using System.Collections;
using UnityEngine;
using static CarController;

namespace Assets.Scripts.Car
{
    public class BuffSpeed : MonoBehaviour
    {
        [SerializeField] private float boostSpeedType01;
        [SerializeField] private float boostSpeedType02;
        [SerializeField] private float timeBuffSpeed;
        [SerializeField] private CarController carControl;
        private CameraFollower mainCam;
        private CarBuffEffect TypeBuff;
        private CarBuffSpeedEffect buffEffect;
        private PowerCar powerCar;
        private bool isBuffSpeed = false;


        private void Start()
        {
            buffEffect = GetComponent<CarBuffSpeedEffect>();
            powerCar = GetComponent<PowerCar>();
            mainCam = Camera.main.gameObject.GetComponent<CameraFollower>();
        }

        

        private void Update()
        {
            BuffEvent();
            DisableBuff();

           
        }

        private void DisableBuff()
        {
            if (!isBuffSpeed)
            {

                mainCam.DisableBoostCar();
            }
        }

        public void BuffEvent()
        {
            if(Input.GetKey(KeyCode.RightShift) && carControl.controlMode == ControlMode.Keyboard)
            {
                BuffSpeedCar();
            }

        }


        public void BuffSpeedCar()
        {
            if (!isBuffSpeed)
            {
                TypeBuff = powerCar.getBuffEffect();


                if (TypeBuff != CarBuffEffect.None)
                {
                    isBuffSpeed = true;
                    StartCoroutine(ProcessBuff());
                }
            }
        }

        public IEnumerator ProcessBuff()
        {

            
            float timeStart = 0;
            buffEffect.BuffEfect(TypeBuff);
            AddCarSpeed(TypeBuff);
            powerCar.UsingPower(TypeBuff);
            while (timeStart < timeBuffSpeed)
            {
                
                mainCam.EnableBoostCar();
                yield return null;
                timeStart += Time.deltaTime;
            }
            buffEffect.ResetEffect();
            
            isBuffSpeed = false;


        }


        public void AddCarSpeed(CarBuffEffect typeBuff)
        {
            if(typeBuff == CarBuffEffect.TypeBuff01)
            {
                carControl.carRigidbody.velocity += boostSpeedType01 * carControl.transform.forward;
            }
            else if(typeBuff == CarBuffEffect.TypeBuff02)
            {
                carControl.carRigidbody.velocity += boostSpeedType02 * carControl.transform.forward;
            }
        }

       
    }
}
