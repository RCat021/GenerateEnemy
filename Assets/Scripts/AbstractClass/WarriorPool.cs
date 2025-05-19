using UnityEngine;
using UnityEngine.Pool;

public abstract class WarriorPool<T> : MonoBehaviour where T : Warrior
{
    [SerializeField] private int _capacity = 5;
    [SerializeField] private int _maxSize = 10;
    [SerializeField] private T _prefab;

    private ObjectPool<T> _pool;

    protected virtual void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: CreateWarrior,
            actionOnGet: ActivateWarrior,
            actionOnRelease: DeactivateWarrior,
            actionOnDestroy: DestroyWarrior,
            collectionCheck: true,
            defaultCapacity: _capacity,
            maxSize: _maxSize
        );
    }

    protected T GetWarrior()
    {
        return _pool.Get();
    }

    private T CreateWarrior()
    {
        return Instantiate(_prefab);
    }

    private void ActivateWarrior(T warrior)
    {
        warrior.Destroed += ReleaseWarrior;
        warrior.gameObject.SetActive(true);
    }

    private void DeactivateWarrior(T warrior)
    {
        warrior.Destroed -= ReleaseWarrior;
        warrior.gameObject.SetActive(false);
    }

    private void DestroyWarrior(T warrior)
    {
        Destroy(warrior.gameObject);
    }

    private void ReleaseWarrior(Warrior warrior)
    {
        if (warrior is T concreteWarrior)
        {
            _pool.Release(concreteWarrior);
        }
    }

    private void OnDestroy()
    {
        _pool?.Clear();
    }
}