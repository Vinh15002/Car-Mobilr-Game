
using Assets.Scripts.CarAIEnemy;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad()]
public class WaypointEditor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
       

 
    public static void OnDrawSceneGizmos(WayPoint waypoint, GizmoType gizmoType)
    {
        if((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.blue;
            
        }
        else
        {
            Gizmos.color = Color.blue * 0.5f;

        }

        Gizmos.DrawSphere(waypoint.transform.position, 0.5f);


        Gizmos.color = Color.white;

        Gizmos.DrawLine(
            waypoint.transform.position + (waypoint.transform.right*waypoint.waypointWidth / 2f),    
            waypoint.transform.position - (waypoint.transform.right*waypoint.waypointWidth / 2f)    
            
        );


        if(waypoint.previousWayPoint != null)
        {
            Gizmos.color = Color.red;

            Vector3 offset = waypoint.transform.right * waypoint.waypointWidth / 2f;
            Vector3 offsetTo = waypoint.previousWayPoint.transform.right * waypoint.previousWayPoint.waypointWidth / 2f;

            Gizmos.DrawLine(
                waypoint.transform.position + offset,
                waypoint.previousWayPoint.transform.position + offsetTo
                
            );
        }

        if (waypoint.nextWayPoint != null)
        {
            Gizmos.color = Color.green;

            Vector3 offset = waypoint.transform.right * -waypoint.waypointWidth / 2f;
            Vector3 offsetTo = waypoint.nextWayPoint.transform.right * -waypoint.nextWayPoint.waypointWidth / 2f;

            Gizmos.DrawLine(
                waypoint.transform.position + offset,
                waypoint.nextWayPoint.transform.position + offsetTo

            );
        }
    }

}
