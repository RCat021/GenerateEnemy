using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private int _spawnCount;

    public Vector3 GetSpawnPosition()
    {
        return _spawnPosition.position;
    }

    public int GetSpawnCount()
    {
        return _spawnCount;
    }
}
