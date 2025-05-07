using UnityEngine;

public class EnemySpawnPosition : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;

    public Vector3 GetSpawnPosition()
    {
        return _spawnPosition.position;
    }
}
