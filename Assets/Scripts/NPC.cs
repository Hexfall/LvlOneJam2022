using System;
using Managers;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using Random = System.Random;

public class NPC : Movable
{
    private void Start()
    {
        if (MaxIdleTime < MinIdleTime || MaxWalkTime < MinWalkTime)
            throw new Exception("Max times cannot be lesser than min times.");
        MaxIdleTime -= MinIdleTime;
        MaxWalkTime -= MinWalkTime;
        GameManager.Instance.AddNPC(this);
    }

    public float MaxIdleTime = 3;
    public float MinIdleTime = 1;
    public float MaxWalkTime = 6;
    public float MinWalkTime = 1;
    [Range(0, 1)]
    public float InstaWalkChance = .66f;

    private readonly Random _rand = new();
    private float _movetime;
    private bool _moving;
    
    private void Update()
    {
        _movetime -= Time.deltaTime;

        if (_movetime <= 0)
        {
            if (_moving && _rand.NextDouble() <= InstaWalkChance)
                StopMoving();
            else
                StartMoving();
        }
    }

    private void StartMoving()
    {
        var angle = _rand.NextDouble() * Math.PI * 2;
        SetDirection(new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle)));
        _movetime = (float) (MinWalkTime + _rand.NextDouble() * MaxWalkTime);
        _moving = true;
    }

    private void StopMoving()
    {
        StopMove();
        _movetime = (float) (MinIdleTime + _rand.NextDouble() * MaxIdleTime);
        _moving = false;
    }
}
