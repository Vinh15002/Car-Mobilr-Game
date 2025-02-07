
using UnityEngine;
using UnityEditor;
using System;
using Assets.Scripts.CarAIEnemy;

namespace Assets.Scripts.Editor
{
    public class WaypointManagerWindow : EditorWindow
    {
        [MenuItem("Waypoint/Waypoints Editor Tools")]
        public static void ShowWindow()
        {
            GetWindow<WaypointManagerWindow>("Waypoints Editor Tools");
        }

        public Transform waypointOrigin;

        public void OnGUI()
        {
            SerializedObject obj = new SerializedObject(this);

            EditorGUILayout.PropertyField(obj.FindProperty("waypointOrigin"));


            if(waypointOrigin == null)
            {
                EditorGUILayout.HelpBox("Please assgin a waypoint Origin transform", MessageType.Warning);
            }
            else
            {
                EditorGUILayout.BeginVertical("Box");
                CreateButtons();
                EditorGUILayout.EndVertical();
            }

            obj.ApplyModifiedProperties();

        }

        private void CreateButtons()
        {
            if(GUILayout.Button("Create Waypoint"))
            {
                CreateWaypoint();
            }
        }

        private void CreateWaypoint()
        {
            GameObject waypointObject = new GameObject("Waypoint " + waypointOrigin.childCount, typeof(WayPoint));

            waypointObject.transform.SetParent(waypointOrigin, false);

            WayPoint waypoint = waypointObject.GetComponent<WayPoint>();

            if(waypointOrigin.childCount > 1)
            {
                waypoint.previousWayPoint = waypointOrigin.GetChild(waypointOrigin.childCount - 2).GetComponent<WayPoint>();

                waypoint.previousWayPoint.nextWayPoint = waypoint;
            
                waypoint.transform.position = waypoint.previousWayPoint.transform.position;
                waypoint.transform.forward = waypoint.previousWayPoint.transform.forward;
            
            }

            Selection.activeObject = waypointObject;

        }
    }
}
