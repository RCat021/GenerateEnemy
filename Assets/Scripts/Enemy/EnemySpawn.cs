
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : Spawner<Enemy>
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] EnemySpawnPosition _enemySpawnPosition;

    private Transform _heroPosition = null;

    public void SetHeroPosition(Transform heroPosition) =>
        _heroPosition = heroPosition;

    override protected void Spawn()
    {
        if (_heroPosition == null)
            return;

        Enemy enemy = _enemyPool.GetEnemy();
        enemy.transform.position = _enemySpawnPosition.GetSpawnPosition();

        InitEnemyDirection(enemy, _heroPosition);
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnRoutine());
    }

    protected void InitEnemyDirection(Enemy enemy, Transform heoroPosition) =>
     enemy.MoveToHero(heoroPosition);
}
