using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSmokeEffect : MonoBehaviour
{
    public ParticleSystem[] smokeEffects;
    private bool smokeEffeectEnable = false;


    private void Start()
    {
        EnableSmokeEffect(false);
    }
    public void setEnableSmokeEffect(bool effect)
    {
        if(effect!=smokeEffeectEnable)
        {
            EnableSmokeEffect(effect);
            smokeEffeectEnable = effect;
        }
    }


    private void EnableSmokeEffect(bool enable)
    {
        foreach (ParticleSystem item in smokeEffects)
        {
            if (enable)
            {
                item.Play();
            }
            else
            {
                item.Stop();
            }
        }
    }
}
