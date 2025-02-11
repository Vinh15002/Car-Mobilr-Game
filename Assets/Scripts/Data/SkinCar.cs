using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public  class SkinCar
{
    public int IDSkin;
    public string SkinColor;
    
    public float Price;

    public override string ToString()
    {
        return "Skin Color: " + this.SkinColor + " Price: " + this.Price;
    }
}

