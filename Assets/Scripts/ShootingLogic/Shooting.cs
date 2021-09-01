using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private AddressableObjectPooler _pooler;

    private void LateUpdate()
    {
        Shoot();
    }

    private void Shoot()
    {
        var obj = _pooler.SpawnFromPool(transform);
        if (obj == null)
        {
            return;
        }
    }
}
