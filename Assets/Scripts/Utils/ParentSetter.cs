using UnityEngine;

public class ParentSetter : MonoBehaviour
{
    [SerializeField]
    private Transform _parentTransform;

    public void SetDynamicParentTransform(Transform parentTransform)
    {
        _parentTransform = parentTransform;
    }

    public void SetParent(GameObject gameObjectToSetParent) => SetParent(gameObjectToSetParent.transform);

    public void SetParent(Transform transformToSetParent)
    {
        transformToSetParent.SetParent(_parentTransform);
    }
}
