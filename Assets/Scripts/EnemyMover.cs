using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;

    private List<Vector3> _waypoints;
    private int _currentWaypointIndex = 0;

    private Vector3 _currentTarget;
    private bool _isPathComplete = true;

    public event Action PathCompleted;

    public void SetPath(List<Vector3> waypoints)
    {
        _waypoints = waypoints;
        _currentWaypointIndex = 0;
        _isPathComplete = false;

        if (_waypoints.Count > 0)
        {
            _currentTarget = _waypoints[0];
            UpdateRotation();
        }
    }

    private void Update()
    {
        if (_isPathComplete)
            return;

        MoveToTarget();
        CheckTargetReached();
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
    }

    private void CheckTargetReached()
    {
        if (Vector3.Distance(transform.position, _currentTarget) < 0.1f)
        {
            _currentWaypointIndex++;

            if (_currentWaypointIndex >= _waypoints.Count)
            {
                _isPathComplete = true;
                PathCompleted?.Invoke();
                return;
            }

            _currentTarget = _waypoints[_currentWaypointIndex];
            UpdateRotation();
        }
    }

    private void UpdateRotation()
    {
        Vector3 direction = (_currentTarget - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
