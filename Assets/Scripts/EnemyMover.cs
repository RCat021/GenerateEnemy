using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;

    private Vector3 _direction;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void SetMovementDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void RotateToDirection()
    {
        transform.rotation = Quaternion.LookRotation(_direction);
    }
}
