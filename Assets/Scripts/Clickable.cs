using UnityEngine;

public class Clickable : MonoBehaviour
{
    private SpriteRenderer _sprite;
    public Color idleColor;
    public Color hoverColor;
    
    private NPCSpawner _spawner;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        _sprite.color = hoverColor;
    }

    private void OnMouseExit()
    {
        _sprite.color = idleColor;
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
