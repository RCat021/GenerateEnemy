using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _timeLife = 5f;

    private EnemyMover _mover;

    public event Action<Enemy> Destroed;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void OnEnable()
    {
        _mover.PathCompleted += OnReachedFinalPoint;
    }

    private void OnDisable()
    {
        _mover.PathCompleted -= OnReachedFinalPoint;
    }

    public void MoveToPoints(List<Vector3> points) =>
        _mover.SetPath(points);

    private void OnReachedFinalPoint()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_timeLife);
        Destroed?.Invoke(this);
    }
}
