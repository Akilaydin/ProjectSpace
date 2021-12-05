using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;

using Cysharp.Threading.Tasks;

[RequireComponent(typeof(IRandomizer))]
public class AddressableObjectPooler : MonoBehaviour
{
    [SerializeField]
    private AssetReference[] _referencesOnObjectToPool;
    
    [SerializeField]
    private int _poolSize;

    private IRandomizer _randomizer;
    
    private Queue<GameObject> _objectsToPool = new Queue<GameObject>();
    
    private bool _isReady;

    private async void Awake()
    {
        _randomizer = GetComponent<IRandomizer>();
        
        _randomizer.SetMax(_referencesOnObjectToPool.Length - 1);
        
        _isReady = false;
        
        await FillQueue();
    }

    public async UniTask FillQueue()
    {
        if (_isReady == false)
        {
            for (int i = 0; i < _poolSize; i++)
            {
                var reference = _referencesOnObjectToPool[UnityEngine.Random.Range(0, _randomizer.GetIndex())];
            
                var spawnedObject = await Addressables.InstantiateAsync(reference);

                spawnedObject.SetActive(false);
            
                _objectsToPool.Enqueue(spawnedObject);
            }
            
            _isReady = true;

        }
    }

    public GameObject SpawnFromPool(Transform spawnTransform)
    {
        if (_isReady == false)
        {
            Debug.Log("Hasn't spawned enough objects yet");
            return null;
        }

        var obj = _objectsToPool.Dequeue();

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