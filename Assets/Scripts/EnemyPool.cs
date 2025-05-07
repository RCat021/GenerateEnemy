using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private int _capacity = 5;
    [SerializeField] private int _maxSize = 5;
    [SerializeField] private Enemy _prefab;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
           createFunc: () => Instantiate(_prefab),
           actionOnGet: ActivateCapsule,
           actionOnRelease: DiactivedCapsule,
           actionOnDestroy: DestroyCapsule,
           collectionCheck: true,
           defaultCapacity: _capacity,
           maxSize: _maxSize
            );
    }

    private void ActivateCapsule(Enemy enemy)
    {
        enemy.Destroing += ReleaseCapsule;
        enemy.gameObject.SetActive(true);
    }

    private void DiactivedCapsule(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void DestroyCapsule(Enemy enemy)
    {
        Destroy(enemy);
    }

    private void ReleaseCapsule(Enemy enemy)
    {
        enemy.Destroing -= ReleaseCapsule;
        _pool.Release(enemy);
    }

    public Enemy GetEnemy()
    {
        return _pool.Get();
    }
}
