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
           actionOnGet: ActivateEnemy,
           actionOnRelease: DiactivedEnemy,
           actionOnDestroy: DestroyEnemy,
           collectionCheck: true,
           defaultCapacity: _capacity,
           maxSize: _maxSize
            );
    }

    private void ActivateEnemy(Enemy enemy)
    {
        enemy.Destroed += ReleaseEnemy;
        enemy.gameObject.SetActive(true);
    }

    private void DiactivedEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void DestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void ReleaseEnemy(Enemy enemy)
    {
        enemy.Destroed -= ReleaseEnemy;
        _pool.Release(enemy);
    }

    public Enemy GetEnemy()
    {
        return _pool.Get();
    }
}
