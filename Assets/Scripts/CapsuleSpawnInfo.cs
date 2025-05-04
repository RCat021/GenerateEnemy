using UnityEngine;

public class CapsuleSpawnInfo : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;

    [SerializeField] private float _capsuleRotateY;

    public float CapsuleRotateY => _capsuleRotateY;

    public Vector3 GetSpawnPosition()
    {
        return _spawnPosition.position;
    }
}
