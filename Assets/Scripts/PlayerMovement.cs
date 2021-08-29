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

    private Tween _movementTween;

    private void Start()
    {
        _movementTween.SetUpdate(UpdateType.Fixed);
    }

    private void OnMouseDown()
    {
        Debug.Log("Down");   
    }

    private void OnMouseDrag()
    {
        Debug.Log("Drag");
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        _movementTween = _rigidbodyToMove.DOMove(new Vector3(objPosition.x, objPosition.y + _distance), _timeToCompleteMovement, false);
    }

    private void OnMouseUp()
    {
        Debug.Log("Up");
        _rigidbodyToMove.DOKill(false);
    }
}
