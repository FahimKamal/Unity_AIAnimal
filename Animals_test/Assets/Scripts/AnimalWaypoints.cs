using System;
using System.Collections.Generic;
using QuickEye.Utility;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Splines;

public class AnimalWaypoints : MonoBehaviour
{
    [SerializeField] private SplineContainer wayPoints;
    [SerializeField] public List<WayPointKnot> wayPointKnots;

    [HideInInspector] public int selectedIndex = -1;

    [ContextMenu("Get Waypoints")]
    public void GetAllWaypoints()
    {
        wayPointKnots.Clear();
        var wayPointCount = wayPoints[0].Count;
        for (var i = 0; i < wayPointCount; i++)
        {
            wayPointKnots.Add(new WayPointKnot() { knotIndex = i, aiAction = AIAction.None });
        }
    }

    private void OnDrawGizmosSelected()
    {
        Draw();
    }

    private void Draw()
    {
        for (int i = 0; i < wayPointKnots.Count; i++)
        {
            var defaultColor = GUI.color;
            if (i == selectedIndex)
            {
                GUI.color = Color.red;
                UnityEditor.Handles.Label(wayPoints[0][i].Position, $"Action:{ Enum.GetName(typeof(AIAction), wayPointKnots[i].aiAction)}");
                GUI.color = defaultColor;
                continue;
            }
            UnityEditor.Handles.Label(wayPoints[0][i].Position, $"Action:{ Enum.GetName(typeof(AIAction), wayPointKnots[i].aiAction)}");
        }
        
    }
}

public enum AIAction
{
    None, Idle, Eat, Sit
}
[Serializable]
public class WayPointKnot
{
    public int knotIndex;
    public AIAction aiAction;
}
