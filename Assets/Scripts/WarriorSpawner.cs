using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSpawner : MonoBehaviour
{
    [SerializeField] private HeroSpawner _heroSpawn;
    [SerializeField] private EnemySpawn _enemySpawn;

    private Transform _lastHeroPosition;

    private void OnEnable()
    {
        _heroSpawn.OnSpawn += SetEnemyChaseTarget;
    }

    private void OnDisable()
    {
        _heroSpawn.OnSpawn -= SetEnemyChaseTarget;
    }

    private void SetEnemyChaseTarget(Hero hero)
    {
        var position = hero.transform;

        _lastHeroPosition = position;

        _enemySpawn.SetHeroPosition(_lastHeroPosition);
    }

}
