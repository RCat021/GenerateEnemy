using System.Collections.Generic;
using UnityEngine;

public class WarriorSpawner : MonoBehaviour
{
    [SerializeField] private HeroSpawner _heroSpawn;
    [SerializeField] private List<EnemySpawn> _enemySpawns;

    private int _targetEnemySpawnIndex = -1;

    private Transform _lastHeroPosition;

    private void OnEnable()
    {
        _heroSpawn.OnSpawned += SetEnemyChaseTarget;
    }

    private void OnDisable()
    {
        _heroSpawn.OnSpawned -= SetEnemyChaseTarget;
    }

    private void SetEnemyChaseTarget(Hero hero)
    {
        var position = hero.transform;

        _lastHeroPosition = position;

        var enemySpawn = _enemySpawns[GetTargetIndex()];

        enemySpawn.SetHeroPosition(_lastHeroPosition);
        enemySpawn.StartSpawn();
    }

    private int GetTargetIndex()
    {
        _targetEnemySpawnIndex++;

        if(_targetEnemySpawnIndex >= _enemySpawns.Count)
            _targetEnemySpawnIndex = 0;

        return _targetEnemySpawnIndex;
    }

}
