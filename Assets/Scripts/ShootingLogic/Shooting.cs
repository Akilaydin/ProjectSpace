using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private AddressableObjectPooler _pooler;

    [SerializeField]
    private float _fireSpeed;

    private float _coolDownTime;

    private bool _hasShot;

    private void Update()
    {
        if(_hasShot==true)
        {
            _coolDownTime += Time.deltaTime;
            if(_coolDownTime>=_fireSpeed)
            {
                _hasShot = false;
                _coolDownTime = 0;
            }
        }
        if(_hasShot==false)
        {
            Shoot();
        }
        
    }

    private void Shoot()
    {
        var obj = _pooler.SpawnFromPool(transform);
        if (obj == null)
        {
            return;
        }
        _hasShot = true;
    }
}

