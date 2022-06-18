using System;
using Managers;
using UnityEngine;
using Random = System.Random;

public class NPC : Movable
{
    private void Start() => GameManager.Instance.AddNPC(this);

    private readonly Random _rand = new();
    private float _movetime;
    private bool _moving;
    
    private void Update()
    {
        _movetime -= Time.deltaTime;

        if (_movetime <= 0)
        {
            if (_moving && _rand.NextDouble() <= .66)
                StopMoving();
            else
                StartMoving();
        }
    }

    private void StartMoving()
    {
        var angle = _rand.NextDouble() * Math.PI * 2;
        SetDirection(new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle)));
        _movetime = (float) (1f + _rand.NextDouble() * 5f);
        _moving = true;
    }

    private void StopMoving()
    {
        StopMove();
        _movetime = (float) (1f + _rand.NextDouble() * 2f);
        _moving = false;
    }
}
