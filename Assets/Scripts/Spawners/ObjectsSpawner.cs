using UnityEngine;

using Cysharp.Threading.Tasks;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField]
    private UnityGameObjectEvent _objectSpawned;
    
    [SerializeField]
    private AddressableObjectPooler _pooler;

    public async void Spawn()
    {
        await SpawnAsync();
    }

    private async UniTask SpawnAsync()
    {
        await _pooler.FillQueue();

        var enemy = _pooler.SpawnFromPool(transform);
        
        enemy.SetActive(true);
        
        _objectSpawned?.Invoke(enemy);
    }
}
