using System.Collections;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour
{
    [SerializeField, Min(0)] private float _timeSpawn = 2f;
    [SerializeField, Min(0)] private int _spawnCount = 1;

    protected IEnumerator SpawnRoutine()
    {
        var time = new WaitForSeconds(_timeSpawn);

        for (int i = 0; i < _spawnCount; i++) 
        {
            Spawn();

            yield return time;
        }
    }

    abstract protected void Spawn();
}
