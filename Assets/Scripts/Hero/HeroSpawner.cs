using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : Spawner<Hero>
{
    [SerializeField] private HeroPool _heroPool;

    [SerializeField] private List<HeroSpawnPosition> _spawnPosition;

    public event Action<Hero> OnSpawned;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    override protected void Spawn()
    {
        Hero hero;
        HeroSpawnPosition spawnPosition;

        for (int i = 0; i < _spawnPosition.Count; i++)
        {
            hero = _heroPool.GetHero();

            spawnPosition = _spawnPosition[i];
            hero.transform.position = spawnPosition.GetSpawnPosition();

            InitHeroDirection(hero, spawnPosition.GetWaypoints());
            OnSpawned?.Invoke(hero);
        }
    }

    private void InitHeroDirection(Hero hero, List<Vector3> points)
    {
        hero.MoveToWaypoints(points);
    }
}
