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
}
