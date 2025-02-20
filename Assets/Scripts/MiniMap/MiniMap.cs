using System;
using UnityEngine;

namespace Assets.Scripts.MiniMap
{
    public class MiniMap: MonoBehaviour
    {
        [SerializeField] private GameObject car;
        [SerializeField] private GameObject cam;
        [SerializeField] private GameObject repersentationImage;



        private void FixedUpdate()
        {
            CameraFollow();
        }
        public void OnEnable()
        {
            ChangeTargetEvent.setTarGetCar += ChangeTarGetCar;
        }
        public void OnDisable()
        {
            ChangeTargetEvent.setTarGetCar -= ChangeTarGetCar;
        }

        private void ChangeTarGetCar(GameObject car)
        {
            this.car = car;
        }

        private void CameraFollow()
        {
            Vector3 positonFollower = car.transform.position;
            cam.transform.position = new Vector3(positonFollower.x, cam.transform.position.y, positonFollower.z);
            //Calculate Angle 
            Vector3 carDirection = car.transform.forward;
            float RotZ = Mathf.Atan2(carDirection.z, carDirection.x) * Mathf.Rad2Deg;
            Quaternion rotationImage = Quaternion.Euler(0, 0, RotZ);
            repersentationImage.transform.rotation = rotationImage;
        }




    }
}
