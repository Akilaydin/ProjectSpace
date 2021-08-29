using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Vector2 _movingDirection;

    [SerializeField]
    private bool _isCamera = true;

    private Transform _selfTransform;


    private void Start()
    {
        _selfTransform = transform;
    }

    private void Update()
    {
        if (_isCamera == false)
        {
            Move();
        }
    }

    private void LateUpdate()
    {
        if (_isCamera == true)
        {
            Move();
        }
    }

    private void Move()
    {
        _selfTransform.Translate(_movingDirection * _speed * Time.deltaTime);
    }
}
