using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;

    public Vector3 GetSpawnPosition()
    {
        return _spawnPosition.position;
    }
}
