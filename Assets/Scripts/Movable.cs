using System;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public const float Speed = 1;
    private Vector2 _dir = Vector2.zero;

    private void FixedUpdate()
    {
        Move();
    }
    
    public void Move()
    {
        transform.Translate(_dir*Speed*Time.fixedDeltaTime);
    }

    public void SetDirection(Vector2 direction)
    {
        _dir = direction.normalized;
    }

    public void StopMove()
    {
        _dir = Vector2.zero;
    }
}
