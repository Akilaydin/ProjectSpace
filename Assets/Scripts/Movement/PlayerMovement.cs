using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [Header("Events")]

    [SerializeField]
    private UnityEvent _onDragBegin;

    [SerializeField]
    private UnityEvent _onDragEnd;

    [Space]
    [Header("Settings")]

    [SerializeField]
    private float _distance;

    [SerializeField]
    private float _timeToCompleteMovement;

    [Space]
    [Header("References")]

    [SerializeField]
    private Rigidbody2D _rigidbodyToMove;

    private Tween _movementTween;

    private void Start()
    {
        _movementTween.SetUpdate(UpdateType.Fixed);
    }

    private void OnMouseDown()
    {
        _onDragBegin.Invoke();
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
        _onDragEnd.Invoke();
    }
}
