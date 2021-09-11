using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHp : MonoBehaviour,IDamagable
{
    [SerializeField]
    private int _initialHp;

    private int _currentHp;

    public void GetDamage(int damageCount)
    {
        throw new System.NotImplementedException();
    }

    public int GetHp()
    {
        return _currentHp;
    }
}

