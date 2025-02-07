using Assets.Scripts.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CarAIEnemy.CarOpponent
{
    public class ResetDestenition : MonoBehaviour
    {
        private OpponentCarWaypoints car;
        private float timeToReset = 30f;
        private float _timeToReset = 0f;

        private bool isReset
        {
            get { return _timeToReset > timeToReset; }
        }
        private void Start()
        {
            car = GetComponent<OpponentCarWaypoints>();
        }


        private void FixedUpdate()
        {
            CalculateTimeReset();
            Reset();
        }




        public void SetNewDestination()
        {
            _timeToReset = 0;
        }

        public void CalculateTimeReset()
        {
            _timeToReset += Time.deltaTime;
          
        }

        public void Reset()
        {
            if(isReset)
            {
                car.SetResetDestenitation();

            }
        }

    }



}
