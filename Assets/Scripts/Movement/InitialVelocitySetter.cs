using Chronos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVelocitySetter : MonoBehaviour
{
    [SerializeField]
    private Vector2 _velocity;

    [SerializeField]
    private Timeline _timeline; 

    public void SetVelocity()
    {
        _timeline.rigidbody2D.velocity = _velocity;
    }
}
