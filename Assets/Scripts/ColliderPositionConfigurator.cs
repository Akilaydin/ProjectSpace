using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPositionConfigurator : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D _leftCollider;

    [SerializeField]
    private BoxCollider2D _rightCollider;

    [SerializeField]
    private ScreenSizeProvider _screenSizeProvider; 

    private void Start()
    {
        _leftCollider.transform.position = _screenSizeProvider.GetLeftSide();
        _rightCollider.transform.position = _screenSizeProvider.GetRightSide();
    }
}


