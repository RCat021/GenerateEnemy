using System.Collections;
using UnityEngine;

public class CapsuleSpawner : MonoBehaviour
{
    [SerializeField] private CapsulePool _pool;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _capsuleRotateY;
    [SerializeField] private float _timeSpawn = 2f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void Spawn()
    {
        var capsule = _pool.GetPool();

        capsule.transform.position = _spawnPosition.position;

        Vector3 currentEuler = capsule.transform.eulerAngles;
        currentEuler.y = _capsuleRotateY;
        capsule.transform.rotation = Quaternion.Euler(currentEuler);
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
