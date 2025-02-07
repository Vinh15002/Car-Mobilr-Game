using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Event
{
    public class SpeedCarEvent
    {
        public delegate void SpeedCarUI(float speed, float maxSpeed);


        public static SpeedCarUI speedCarUI;


    }
}
