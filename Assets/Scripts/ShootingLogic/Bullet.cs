using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private InitialVelocitySetter _initialVelocitySetter;

    [SerializeField]
    private int _damageHEHEHEHECount;
    public void OnSpawnedAction()
    {
        _initialVelocitySetter.SetVelocity();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable damagable = collision.GetComponent<IDamagable>();

        if(damagable!=null)
        {
            Debug.Log("маслину поймал");
        }
        
    }
}
