using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPosition : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private List<Transform> _waypoints;

    public Vector3 GetSpawnPosition()
    {
        return _spawnPosition.position;
    }

    public List<Vector3> GetWaypoints()
    {
        List<Vector3> waypointPositions = new List<Vector3>();

        foreach (Transform waypoint in _waypoints)
                waypointPositions.Add(waypoint.position);

        return waypointPositions;
    }
}
