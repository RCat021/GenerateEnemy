using System;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;

    private Vector3 _currentTarget;

    public event Action PathCompleted;

    public void SetPath(Vector3 waypoint)
    {
        _currentTarget = waypoint;

        UpdateRotation();
    }

    protected void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
    }

    protected void UpdateRotation()
    {
        Vector3 direction = (_currentTarget - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
