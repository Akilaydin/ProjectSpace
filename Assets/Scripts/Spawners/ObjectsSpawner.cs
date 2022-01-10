using System;

using UnityEngine;

using Cysharp.Threading.Tasks;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField]
    private UnityGameObjectEvent _objectSpawned;
    
    [SerializeField]
    private AddressableObjectPooler _pooler;

    [SerializeField]
    private Transform _rootTransform;

    private void OnValidate()
    {
        if (_rootTransform == null)
        {
            _rootTransform = transform;
        }
    }

    public async void Spawn()
    {
        await SpawnAsync();
    }

    private async UniTask SpawnAsync()
    {
        await _pooler.FillQueue();

        var spawnedObject = _pooler.SpawnFromPool(_rootTransform);
        
        spawnedObject.SetActive(true);
        
        _objectSpawned?.Invoke(spawnedObject);
    }
}
