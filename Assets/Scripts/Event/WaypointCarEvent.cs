
using UnityEngine;

namespace Assets.Scripts.Event
{
    public class WaypointCarEvent
    {
        public delegate void ChangeDestenitation();
        public static ChangeDestenitation changeDestination;
    }
}
