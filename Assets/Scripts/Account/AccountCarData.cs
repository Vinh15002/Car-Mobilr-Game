
using System;
using System.Collections.Generic;


[Serializable]
public class AccountCarData
{
    public int IDcar;
    public int currentSpeedLevel;
    public int currentBuffLevel;

    public List<int> IDSkinCars = new List<int>();

    public AccountCarData(int iDcar, int currentSpeedLevel, int currentBuffLevel)
    {
        IDcar = iDcar;
        this.currentSpeedLevel = currentSpeedLevel;
        this.currentBuffLevel = currentBuffLevel;
        
    }
}

