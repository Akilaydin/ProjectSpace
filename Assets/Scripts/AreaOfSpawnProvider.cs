using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfSpawnProvider : MonoBehaviour
{
    [SerializeField]
    private float _height;

    [SerializeField]
    private float _offSetY;

    private Rect _rect;

    private void Awake()
    {
        CalculateArea();
    }

    private void CalculateArea()
    {
        var widthSenter = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        var rightPosition = new Vector2(widthSenter.x, widthSenter.y + _offSetY);
        var leftPosition = new Vector2(-widthSenter.x, widthSenter.y + _offSetY);

        _rect.x = leftPosition.x;
        _rect.y = leftPosition.y;

        _rect.width = rightPosition.x - leftPosition.x;
        _rect.height = _height;
    }

    public Rect GetArea()
    {
        return _rect;
    }
}
