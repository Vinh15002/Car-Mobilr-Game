
using System;
using System.Collections.Generic;



[Serializable]
public class Car
{
    public int IDCar;
    public float Price;
   
    public LevelCar level;
    public List<SkinCar> skinCars;

    public override string ToString()
    {
        return "ID: " + IDCar + "Price: " + Price + "Skin Car " + skinCars.ToString();
    }
}


