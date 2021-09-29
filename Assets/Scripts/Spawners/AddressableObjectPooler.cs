using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableObjectPooler : MonoBehaviour
{
    [SerializeField]
    private AssetReference _referenceOnObjectToPool;

    [SerializeField]
    private int _poolSize;

    private bool _isReady;
    private Queue<GameObject> _objectsToPool = new Queue<GameObject>();

    private void Awake()
    {
        _isReady = false;
        FillQueue();
    }

    private async void FillQueue()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            var spawnedObject = await Addressables.InstantiateAsync(_referenceOnObjectToPool).Task;

            spawnedObject.SetActive(false);
            _objectsToPool.Enqueue(spawnedObject);
        }
        _isReady = true;
    }

    public GameObject SpawnFromPool(Transform spawnTransform)
    {
        if (_isReady == false)
        {
            Debug.Log("Hasn't spawned enough objects yet");
            return null;
        }

        GameObject obj = _objectsToPool.Dequeue();

        obj.SetActive(true);
        obj.transform.position = spawnTransform.position;
        obj.transform.rotation = spawnTransform.rotation;


        if (obj.TryGetComponent(out IPooledObject pooledObjectComponent))
        {
            pooledObjectComponent.OnSpawnedAction();
        }

        _objectsToPool.Enqueue(obj);

        return obj;
    }
}