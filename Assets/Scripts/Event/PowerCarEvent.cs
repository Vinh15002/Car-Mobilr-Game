using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Event
{
    public class PowerCarEvent
    {
        public delegate void AddPower(float amount);

        public static AddPower addPower;


        public delegate  void GetPresentPower(float present);
        public static GetPresentPower getPresentPower;


        public delegate void PowerFull(bool status);
        public static PowerFull powerFull;
    }
}
