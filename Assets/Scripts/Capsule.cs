using System;
using System.Collections;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _timeLife = 5f;

    public event Action<Capsule> Relised;

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private IEnumerator Destroy()
    {
        Debug.Log("Enum");
        yield return new WaitForSeconds(_timeLife);
        Relised?.Invoke(this);

    }
}
