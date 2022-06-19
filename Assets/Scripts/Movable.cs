using System;
using Unity.VisualScripting;
using UnityEngine;

public class Movable : MonoBehaviour
{
    [Serialize] public const float Speed = 1;
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

    public void SetDirection(Vector2 direction)
    {
        _dir = direction.normalized;
        Rb.velocity = _dir * Speed;
    }

    public void StopMove()
    {
        SetDirection(Vector2.zero);
    }
}
