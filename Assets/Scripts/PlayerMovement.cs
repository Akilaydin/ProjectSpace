using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _distance;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private Rigidbody2D _transformToMove;

    private void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        _transformToMove.DOMove(new Vector3(objPosition.x, objPosition.y + _distance), _speed, false);
    }
}
