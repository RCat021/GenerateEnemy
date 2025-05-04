using UnityEngine;
using UnityEngine.Pool;

public class CapsulePool : MonoBehaviour
{
    [SerializeField] private int _capacity = 5;
    [SerializeField] private int _maxSize = 10;
    [SerializeField] private Capsule _prefab;

    private ObjectPool<Capsule> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Capsule>(
           createFunc: () => Instantiate(_prefab),
           actionOnGet: ActivateCapsule,
           actionOnRelease: DiactivedCapsule,
           actionOnDestroy: DestroyCapsule,
           collectionCheck: true,
           defaultCapacity: _capacity,
           maxSize: _maxSize
            );
    }

    private void ActivateCapsule(Capsule capsule)
    {
        capsule.Relised += ReleaseCapsule;
        capsule.gameObject.SetActive(true);
    }

    private void DiactivedCapsule(Capsule capsule)
    {
        capsule.gameObject.SetActive(false);
    }

    private void DestroyCapsule(Capsule capsule)
    {
        Destroy(capsule);
    }

    private void ReleaseCapsule(Capsule capsule)
    {
        Debug.Log("Relise");
        capsule.Relised -= ReleaseCapsule;
        _pool.Release(capsule);
    }

    public Capsule GetPool()
    {
        return _pool.Get();
    }
}
