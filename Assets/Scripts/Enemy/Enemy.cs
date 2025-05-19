using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : Warrior
{
    private EnemyMover _mover;
    
    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    public void MoveToHero(Transform heroPosition) =>
        _mover.SetHeroPosition(heroPosition);
}
