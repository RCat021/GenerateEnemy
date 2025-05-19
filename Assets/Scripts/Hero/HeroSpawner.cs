using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : Spawner<Hero>
{
    [SerializeField] HeroPool _heroPool;

    [SerializeField] List<HeroSpawnPosition> _spawnPosition;

    public event Action<Hero> OnSpawn;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    override protected void Spawn()
    {
        Hero hero = _heroPool.GetHero();

        var spawnPosition = GetRandomSpawnPosition();
        hero.transform.position = spawnPosition.GetSpawnPosition();

        InitHeroDirection(hero, spawnPosition.GetWaypoints());
        OnSpawn?.Invoke(hero);
    }

    private void InitHeroDirection(Hero hero, List<Vector3> points)
    {
        hero.MoveToWaypoints(points);
    }

    private HeroSpawnPosition GetRandomSpawnPosition()
    {
        return _spawnPosition[UnityEngine.Random.Range(0, _spawnPosition.Count)];
    }
}
