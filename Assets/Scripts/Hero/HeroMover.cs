using System.Collections.Generic;
using UnityEngine;

public class HeroMover : Mover
{
    private List<Vector3> _waypoints;
    private Vector3 _currentTarget;
    private int _currentIndex = 0;

    private void Update()
    {
        if (_waypoints == null)
            return;

        if (GetTargetReached())
        {
            _currentIndex++;

            if (_currentIndex >= _waypoints.Count)
                _currentIndex = 0;

            _currentTarget = _waypoints[_currentIndex];

            SetPath(_currentTarget);
        }

        MoveToTarget();
    }

    public void SetWaypoints(List<Vector3> waypoints)
    {
        _waypoints = waypoints;

        _currentTarget = _waypoints[0];

        SetPath(_currentTarget);
    }

    private bool GetTargetReached()
    {
        return transform.position.IsEnoughClose(_currentTarget, 0.1f);
    }
}

