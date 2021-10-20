using UnityEngine;
using UnityEngine.Events;

public class SpawnAreaCalculator : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _areaOfSpawnCalculated;

    [SerializeField]
    private ScreenSizeProvider _provider;

    [SerializeField]
    private float _height;

    [SerializeField]
    private float _offSetY;

    private Rect _rect;

    public void CalculateSpawnArea()
    {
        var _leftSide = _provider.GetLeftSide();
        var _rightSide = _provider.GetRightSide();

        _rect.x = _leftSide.x;
        _rect.y = _leftSide.y + _offSetY;

        _rect.width = _rightSide.x - _leftSide.x;
        _rect.height = _height;

        _areaOfSpawnCalculated?.Invoke();
    }
}
