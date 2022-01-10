using UnityEngine;

public class EnemiesOnScreenPositioner : MonoBehaviour
{
    [SerializeField]
    private SpawnAreaCalculator _spawnAreaCalculator;

    public void SetEnemyPosition(GameObject enemy) => SetEnemyPosition(enemy.transform);

    public void SetEnemyPosition(Transform enemyTransform)
    {
        enemyTransform.position = _spawnAreaCalculator.GetRandomPosition();
    }
}
