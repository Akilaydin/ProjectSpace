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
        GetRandomPosition();
    }
    
    public Vector2 GetRandomPosition()
    {
        var positionX = Random.Range(_rect.xMin, _rect.xMax);
        var positionY = Random.Range(_rect.yMin, _rect.yMax);
        var position = new Vector2(positionX, positionY);
        return position;
    }

}
