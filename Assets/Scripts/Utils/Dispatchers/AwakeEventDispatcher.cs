using UnityEngine;
using UnityEngine.Events;

public class AwakeEventDispatcher : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onAwake;

    private void Awake()
    {
        _onAwake?.Invoke();
    }
}
