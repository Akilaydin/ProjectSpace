using UnityEngine;
using UnityEngine.Events;

using Cysharp.Threading.Tasks;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private UnityGameObjectEvent _enemySpawned;
    
    [SerializeField]
    private AddressableObjectPooler _enemyPooler;

    private async void Awake()
    {
        await Spawn();
    }

    private async UniTask Spawn()
    {
        await _enemyPooler.FillQueue();

        var enemy = _enemyPooler.SpawnFromPool(transform);
        
        enemy.SetActive(true);
        
        _enemySpawned?.Invoke(enemy);
    }
}
