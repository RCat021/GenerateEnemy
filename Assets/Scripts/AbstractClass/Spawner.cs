using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour
{
    [SerializeField] private float _timeSpawn = 2f;

    protected IEnumerator SpawnRoutine()
    {
        bool isSpawned = enabled;
        var time = new WaitForSeconds(_timeSpawn);

        while (isSpawned)
        {
            Spawn();

            yield return time;
        }
    }

    abstract protected void Spawn();
}
