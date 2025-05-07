using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _timeLife = 5f;

    public event Action<Enemy> Destroing;

    private EnemyMover _mover;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy());
        _mover.SetMovementDirection();
    }

    private IEnumerator Destroy()
    {
        Debug.Log("Enum");
        yield return new WaitForSeconds(_timeLife);
        Destroing?.Invoke(this);
    }
}
