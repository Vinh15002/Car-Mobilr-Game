using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


[Serializable]
public class LevelCar
{
    public float speedCar = 900;
    public float powerCar = 20;

    public List<int> CoinSpeed;
    public List<int> CoinBuff;

    public int currentSpeedLevel;
    public int currentBuffLevel;



    public float getSpeedCar()
    {
        if(currentSpeedLevel == 1)
        {
            return speedCar;

        }
        else if(currentSpeedLevel == 2)
        {
            return speedCar + 50;
        }
        else if(currentSpeedLevel == 3)
        {
            return speedCar + 100;
        }
        else if(currentSpeedLevel == 4)
        {
            return speedCar + 200;
        }
        else if(currentSpeedLevel == 5)
        {
            return speedCar + 300;
        }
        else
        {
            return speedCar + 500;
        }

    }




    public int GetCoinNextSpeed()
    {
        return CoinSpeed[currentSpeedLevel];
    }

    public int GetCoinNextBuff() {
        return CoinBuff[currentBuffLevel];
    
    }
}

