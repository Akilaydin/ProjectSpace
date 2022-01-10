using UnityEngine;

using Chronos;

[RequireComponent(typeof(Timeline))]
public class Mover : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Vector2 _movingDirection;

    private Transform _selfTransform;

    private Timeline _timeline;

    private void Start()
    {
        _timeline = GetComponent<Timeline>();
        _selfTransform = transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _selfTransform.Translate(_movingDirection * _speed * _timeline.clock.deltaTime);
    }
}
