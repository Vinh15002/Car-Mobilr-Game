using UnityEngine;

namespace Assets.Scripts.CarAIEnemy
{
    public class WayPoint : MonoBehaviour
    {
        [Header("Waypoint Status")]
        public WayPoint previousWayPoint;
        public WayPoint nextWayPoint;

        [Range(0f, 10f)]
        public float waypointWidth = 5f;

        public Vector3 GetPosition()
        {
            Vector3 minBound = transform.position + transform.right * waypointWidth /2;
            Vector3 maxBound = transform.position - transform.right * waypointWidth /2;

            return Vector3.Lerp(minBound, maxBound, Random.Range(0f,1f));

        }


    }
}
