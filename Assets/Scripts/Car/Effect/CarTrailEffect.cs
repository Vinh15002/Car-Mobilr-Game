using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Car
{
    public class CarTrailEffect : MonoBehaviour
    {
        [SerializeField] TrailRenderer[] trails;
        private bool trainEnable = false;


        private void Start()
        {
            TrailEnable(false);
        }

        public void SetTrailEnable(bool trailsenable)
        {
            if (trainEnable != trailsenable)
            {
                TrailEnable(trailsenable);
                trainEnable = trailsenable;
            }
        }

        public void TrailEnable(bool enable)
        {
            foreach (var trail in trails)
            {
                
                 trail.emitting = enable;
              
            }
        }
    }

    
}
