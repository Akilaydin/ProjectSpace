using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _distance;

    [SerializeField]
    private float _timeToCompleteMovement;
    [SerializeField]
    private Rigidbody2D _rigidbodyToMove;

    [SerializeField]
    private TimeController _timeController;

    private Tween _movementTween;

    private void Start()
    {
        _movementTween.SetUpdate(UpdateType.Fixed);
    }

    private void OnMouseDown()
    {
        _timeController.NormalizeTime();
    }

    private void OnMouseDrag()
    {
        
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        _movementTween = _rigidbodyToMove.DOMove(new Vector3(objPosition.x, objPosition.y + _distance), _timeToCompleteMovement, false);
    }

    private void OnMouseUp()
    {      
        _rigidbodyToMove.DOKill(false);
        _timeController.SlowTime();
    }
}
