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



    public float getSpeedCar(int level)
    {
        if(level == 0)
        {
            return speedCar;

        }
        else if(level == 1)
        {
            return speedCar + 50;
        }
        else if(level == 2)
        {
            return speedCar + 100;
        }
        else if(level == 3)
        {
            return speedCar + 200;
        }
        else if(level == 4)
        {
            return speedCar + 300;
        }
        else
        {
            return speedCar + 500;
        }

    }

    public float getPowerCar()
    {
        return powerCar;
    }




    public int GetCoinNextSpeed()
    {
        return CoinSpeed[currentSpeedLevel];
    }

    public int GetCoinNextBuff() {
        return CoinBuff[currentBuffLevel];
    
    }
}

