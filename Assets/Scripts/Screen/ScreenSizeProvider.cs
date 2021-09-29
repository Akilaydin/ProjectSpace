using UnityEngine;

public class ScreenSizeProvider : MonoBehaviour
{
    [SerializeField]
    private float _height;

    [SerializeField]
    private float _offSetY;

    private Rect _rect;

    private Vector2 _rightSide, _leftSide;

    private void Awake()
    {
        CalculateArea();
    }

    private void CalculateArea()
    {
        var widthSenter = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        _rightSide = new Vector2(widthSenter.x, widthSenter.y + _offSetY);
        _leftSide = new Vector2(-widthSenter.x, widthSenter.y + _offSetY);

        _rect.x = _leftSide.x;
        _rect.y = _leftSide.y;

        _rect.width = _rightSide.x - _leftSide.x;
        _rect.height = _height;
    }

    public Rect GetArea()
    {
        return _rect;
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
