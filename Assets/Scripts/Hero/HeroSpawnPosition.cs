using System.Collections.Generic;
using UnityEngine;

public class HeroSpawnPosition : SpawnPosition
{
    [SerializeField] private List<Transform> _waypoints = new List<Transform>();

    public List<Vector3> GetWaypoints()
    {
        List<Vector3> waypoints = new List<Vector3>();

        foreach (Transform waypoint in _waypoints)
            waypoints.Add(waypoint.position);

        return waypoints;
    }
}
