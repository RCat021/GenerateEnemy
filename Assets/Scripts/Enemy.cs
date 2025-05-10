using System;
using System.Collections;
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
        StartCoroutine(Destroy());
    }

    public void SetMovementDirection(Vector3 direction) =>
        _mover.SetMovementDirection(direction);

    public void RotateToDirection() => 
        _mover.RotateToDirection();

    private IEnumerator Destroy()
    {
        Debug.Log("Enum");
        yield return new WaitForSeconds(_timeLife);
        Destroed?.Invoke(this);
    }
}
