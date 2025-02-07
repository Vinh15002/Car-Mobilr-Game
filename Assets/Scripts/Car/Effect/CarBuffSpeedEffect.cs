using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Car.Effect
{
    public class CarBuffSpeedEffect : MonoBehaviour
    {
        [SerializeField] ParticleSystem[] effects;
        [SerializeField] ParticleSystem effectHead;
        [SerializeField] GameObject effectFullScreen;

        public void Start()
        {
            ResetEffect();
        }
        public void ResetEffect()
        {
            foreach (var effect in effects)
            {
                effect.Stop();
            }
            effectHead.Stop();
            effectFullScreen.SetActive(false);
        }

        public void BuffEfect(CarBuffEffect buffType)
        {
            ResetEffect();
            effectHead.Play();
            if (buffType == CarBuffEffect.TypeBuff01)
            {
                effects[0].Play();
            }
            else if(buffType == CarBuffEffect.TypeBuff02)
            {
                effectFullScreen.SetActive(true);
                effects[1].Play();
            }
            
        }
    }
}
