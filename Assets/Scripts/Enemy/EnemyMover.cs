using UnityEngine;

public class EnemyMover : Mover
{
    private Transform _heroPosition;

    private void Update()
    {
        SethPat(_heroPosition.position);
        MoveToTarget();
    }

    public void SetHeroPosition(Transform position) =>
        _heroPosition = position;
}
