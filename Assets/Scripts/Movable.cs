using System;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public const float Speed = 1;
    private Vector2 _dir = Vector2.zero;
    private Rigidbody2D _rb;
    private Rigidbody2D Rb
    {
        get
        {
            if (_rb == null)
                _rb = GetComponent<Rigidbody2D>();

            return _rb;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    public void Move()
    {
        //transform.Translate(_dir*Speed*Time.fixedDeltaTime);
    }

    public void SetDirection(Vector2 direction)
    {
        _dir = direction.normalized;
        Rb.velocity = _dir;
    }

    public void StopMove()
    {
        SetDirection(Vector2.zero);
    }
}
