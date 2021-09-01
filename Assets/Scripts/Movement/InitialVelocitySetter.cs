using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVelocitySetter : MonoBehaviour
{
    [SerializeField]
    private Vector2 _velocity;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    public void SetVelocity()
    {
        _rigidbody.velocity = _velocity;
    }
}
