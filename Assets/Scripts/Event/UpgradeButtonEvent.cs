using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class UpgradeButtonEvent
{
    public delegate void ChangeTextSpeed(int amount, int level);
    public static ChangeTextSpeed changeTextSpeed;


    public delegate void ChangeTextPower(int amount, int level);
    public static ChangeTextPower changeTextPower;
}

