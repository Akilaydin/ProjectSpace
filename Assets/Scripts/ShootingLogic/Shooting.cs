using Chronos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timeline))]
public class Shooting : MonoBehaviour
{
    [SerializeField]
    private AddressableObjectPooler _pooler;

    [Tooltip("Bullets per second")]
    [SerializeField]
    private float _fireSpeed;

    private bool _isAbleToShoot = true;
    private Timeline _timeline;

    private void Start()
    {
        _timeline = GetComponent<Timeline>();
        StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        yield return _timeline.WaitForSeconds(_fireSpeed);

        while (_isAbleToShoot == true)
        {
            var obj = _pooler.SpawnFromPool(transform);
            if (obj == null)
            {
                yield return null;
            }
            yield return _timeline.WaitForSeconds(_fireSpeed);
        }
        
    }
}

