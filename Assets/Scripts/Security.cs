using System;
using Managers;
using UnityEngine;

public class Security : MonoBehaviour
{
    public float spawnTime = 1;
    public float holdTime = 1;
    public float despawnTime = 1;
    public float speed = 5;
    
    private GameObject _target;
    private Vector2 _spawn;
    private bool _abducted;
    private bool _gotPlayer;
    private Vector2 Dir => ((_abducted ? _spawn : _target.transform.position) - transform.position).normalized;

    private void Start()
    {
        _spawn = transform.position;
    }

    private void FixedUpdate()
    {
        if (!_abducted)
        {
            if (spawnTime > 0)
                spawnTime -= Time.fixedDeltaTime;
            else
            {
                if (Vector2.Distance(transform.position, _target.transform.position) <= speed * Time.fixedDeltaTime)
                {
                    transform.position = _target.transform.position;
                    Abduct(_target);
                }
                else
                {
                    transform.Translate(Dir * speed * Time.fixedDeltaTime);
                }
            }
        }
        else
        {
            if (holdTime > 0)
                holdTime -= Time.fixedDeltaTime;
            else
            {
                if ((Vector2) transform.position != _spawn)
                {
                    if (Vector2.Distance(transform.position, _spawn) <= speed * Time.fixedDeltaTime)
                        transform.position = _spawn;
                    else
                        transform.Translate(Dir * speed * Time.fixedDeltaTime);
                }
                else
                {
                    if (despawnTime > 0)
                        despawnTime -= Time.fixedDeltaTime;
                    else
                        SelfDestruct();
                }
            }
        }
    }

    private void SelfDestruct()
    {
        if (_gotPlayer)
            GameManager.Instance.SeekerWon();
        Destroy(gameObject);
    }

    private void Abduct(GameObject target)
    {
        if (target.GetComponent<Player>() != null)
            _gotPlayer = true;
        var movableComponent = target.GetComponent<Movable>();
        if (movableComponent != null)
            Destroy(movableComponent);
        var rb = target.GetComponent<Rigidbody2D>();
        if (rb != null)
            Destroy(rb);
        target.transform.parent = transform;
        _abducted = true;
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }
}
