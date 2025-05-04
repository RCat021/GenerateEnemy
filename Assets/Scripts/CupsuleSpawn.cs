using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupsuleSpawn : MonoBehaviour
{
    [SerializeField] private List<CapsuleSpawnInfo> _spawnInfo = new List<CapsuleSpawnInfo>();
    [SerializeField] private CapsulePool _pool;
    [SerializeField] private float _timeSpawn = 2f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void Spawn()
    {
        var capsule = _pool.GetPool();
        CapsuleSpawnInfo capsuleSpawnInfo = GetRandomSpawnInfo();

        capsule.transform.position = capsuleSpawnInfo.GetSpawnPosition();

        Vector3 currentEuler = capsule.transform.eulerAngles;
        currentEuler.y = capsuleSpawnInfo.CapsuleRotateY;
        capsule.transform.rotation = Quaternion.Euler(currentEuler);
    }

    private CapsuleSpawnInfo GetRandomSpawnInfo()
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
