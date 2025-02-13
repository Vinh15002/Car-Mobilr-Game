
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.CarAIEnemy.CarOpponent
{
    public class RandomBuffSpeed : MonoBehaviour
    {
        private OpponentCar car;

        [Header("Buff Speed Variable")]
        [SerializeField] private float minBuffSpeed = 10f;
        [SerializeField] private float maxBuffSpeed = 20f;

        [SerializeField] private float timeToBuff = 15f;
        private float _timeToBuff = 5f;

        private bool isBuffSpeed = false;


        private void Start()
        {
            car = GetComponent<OpponentCar>();
        }


        private void FixedUpdate()
        {
            BuffSpeed();
        }


        public void BuffSpeed()
        {
            if(!isBuffSpeed)
            {
                int buffType = Random.Range(0, 10);
                buffType = buffType > 5 ? -1 : 1;
                StartCoroutine(BuffSpeedCountine(buffType));
            }
        }

        private IEnumerator BuffSpeedCountine(int buffType)
        {
            isBuffSpeed = true;
            float speedBuff = Random.Range(minBuffSpeed, maxBuffSpeed);
            car.currentSpeed += speedBuff*buffType;
            car.currentSpeed = car.currentSpeed >= 3 ? car.currentSpeed : 3;
            yield return new WaitForSeconds(_timeToBuff);
            
            isBuffSpeed = false;
            setRandomBuffSpeed();
        }

        public void setRandomBuffSpeed()
        {
            _timeToBuff = Random.Range(5f, timeToBuff);
        }





    }
}
