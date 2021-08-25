using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector2 movingDirection;

    private Transform selfTransform;
    
    
    void Start()
    {
        selfTransform = transform;
    }

    
    void Update()
    {
        Move(); 
    }

    private void Move()
    {
        selfTransform.Translate(movingDirection * speed * Time.deltaTime);
    }
}
