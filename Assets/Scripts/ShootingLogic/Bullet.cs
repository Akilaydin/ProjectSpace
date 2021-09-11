using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private InitialVelocitySetter _initialVelocitySetter;
    [SerializeField]
    private int damageHEHEHEHECount;
    public void OnSpawnedAction()
    {
        _initialVelocitySetter.SetVelocity();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IDamagable>().GetDamage(damageHEHEHEHECount);
    }
}
