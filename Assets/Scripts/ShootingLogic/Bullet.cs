using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private InitialVelocitySetter _initialVelocitySetter;

    public void OnSpawnedAction()
    {
        _initialVelocitySetter.SetVelocity();
    }
}
