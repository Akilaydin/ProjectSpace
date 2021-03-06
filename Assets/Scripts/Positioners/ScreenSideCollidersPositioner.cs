using UnityEngine;

public class ScreenSideCollidersPositioner : MonoBehaviour
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


