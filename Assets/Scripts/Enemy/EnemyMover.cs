using UnityEngine;

public class EnemyMover : Mover
{
    private Transform _heroPosition;

    private void Update()
    {
        SetPath(_heroPosition.position);
        MoveToTarget();
    }

    public void SetHeroPosition(Transform position) =>
        _heroPosition = position;
}
