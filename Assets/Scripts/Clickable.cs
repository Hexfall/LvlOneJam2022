using UnityEngine;

public class Clickable : MonoBehaviour
{
    private SpriteRenderer _sprite;
    public Sprite idleSprite;
    public Sprite hoverSprite;
    
    private NPCSpawner _spawner;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        _sprite.sprite = hoverSprite;
    }

    private void OnMouseExit()
    {
        _sprite.sprite = idleSprite;
    }

    private void OnMouseDown()
    {
        _spawner.SpawnSecurity(gameObject);
        OnMouseExit();
        Destroy(this);
    }

    public void SetSpawner(NPCSpawner spawner)
    {
        _spawner = spawner;
    }
}
