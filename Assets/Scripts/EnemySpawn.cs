using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<EnemySpawnPosition> _spawnInfo = new List<EnemySpawnPosition>();
    [SerializeField] private EnemyPool _pool;
    [SerializeField] private float _timeSpawn = 2f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void Spawn()
    {
        var enemy = _pool.GetEnemy();

        EnemySpawnPosition enemySpawnPosition = GetRandomSpawnInfo();
        enemy.transform.position = enemySpawnPosition.GetSpawnPosition();

        InitEnemyDirection(enemy);
    }

    private EnemySpawnPosition GetRandomSpawnInfo()
    {
        return _spawnInfo[Random.Range(0, _spawnInfo.Count)];
    }

    private IEnumerator SpawnRoutine()
    {
        bool isSpawned = enabled;
        var time = new WaitForSeconds(_timeSpawn);

        while (isSpawned)
        {
            Spawn();

            yield return time;
        }
    }

    private Vector3 GetRandomDirection()
    {
        Vector3 direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        if (direction.Equals(Vector3.zero))
            direction = Vector3.forward;

        return direction;
    }

    private void InitEnemyDirection(Enemy enemy)
    {
        enemy.SetMovementDirection(GetRandomDirection());
        enemy.RotateToDirection();
    }
}
