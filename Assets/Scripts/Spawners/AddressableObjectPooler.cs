using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableObjectPooler : MonoBehaviour
{
    [SerializeField]
    private AssetReference _referenceOnObjectToPool;

    [SerializeField]
    private int _poolSize;

    private bool _isReady;
    private Queue<GameObject> _objectsToPool;

    private void Awake()
    {
        _objectsToPool = new Queue<GameObject>();
        _isReady = false;
        FillQueue();
        
    }

    private async void FillQueue()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            var handle = Addressables.InstantiateAsync(_referenceOnObjectToPool);
            await handle.Task;

            GameObject obj = handle.Result;
            obj.SetActive(false);
            _objectsToPool.Enqueue(obj);
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

        var pooledObjectComponent = obj.GetComponent<IPooledObject>();

        if (pooledObjectComponent != null)
        {
            pooledObjectComponent.OnSpawnedAction();
        }

        _objectsToPool.Enqueue(obj);
        return obj;
    }

}