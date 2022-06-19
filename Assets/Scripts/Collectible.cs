using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float destructDelay = 5;
    
    private bool _destructing;
    
    private void Start()
    {
        GameManager.Instance.AddCollectible();
    }

    private void EnableSelfDestruct()
    {
        _destructing = true;
        GameManager.Instance.RemoveCollectible();
    }

    private void Update()
    {
        if (!_destructing)
            return;
        destructDelay -= Time.deltaTime;
        if (destructDelay <= 0)
            SelfDestruct();
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_destructing)
            return;
        if (other.GetComponent<NPC>() != null)
            return;
        if (other.GetComponent<Player>() != null)
            EnableSelfDestruct();
    }
}
