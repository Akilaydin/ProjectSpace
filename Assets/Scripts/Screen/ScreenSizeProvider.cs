using UnityEngine;
using UnityEngine.Events;

public class ScreenSizeProvider : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _sidesCalculated;

    private Vector2 _rightSide, _leftSide;

    private void Awake()
    {
        CalculateArea();
    }

    private void CalculateArea()
    {
        var widthSenter = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        _rightSide = new Vector2(widthSenter.x, widthSenter.y);
        _leftSide = new Vector2(-widthSenter.x, widthSenter.y);

        _sidesCalculated?.Invoke();
    }

    public Vector2 GetLeftSide()
    {
        return _leftSide;
    }

    public Vector2 GetRightSide()
    {
        return _rightSide;
    }
}
