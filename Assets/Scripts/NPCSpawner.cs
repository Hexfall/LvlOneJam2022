using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class NPCSpawner : MonoBehaviour
{
    public Vector2 SpawnArea = Vector2.zero;
    public Vector2 SpawnOffset = Vector2.zero;
    public List<Vector2> BannedSpawnAreas = new();
    public List<Vector2> BannedSpawnOffsets = new();
    public List<Vector2> SecuritySpawns = new();
    public GameObject Security;
    public GameObject NPC;
    public int NPCCount = 100;

    private Random _rand = new();
    private bool _createdPlayer;
    
    private void Awake()
    {
        if (BannedSpawnAreas.Count < BannedSpawnOffsets.Count)
            throw new Exception("Cannot have more offsets than areas.");
    }

    private void Start()
    {
        for (int i = 0; i < NPCCount; i++)
        {
            var go = Instantiate(NPC, GetRandomSpawnPoint(), Quaternion.identity);
            go.GetComponent<Clickable>()?.SetSpawner(this);
            go.transform.parent = transform;
            if (!_createdPlayer)
            {
                go.AddComponent<Player>();
                _createdPlayer = true;
            }
        }
    }

    private Vector2 GetRandomSpawnPoint()
    {
        Vector2 v = new(
            (float) (_rand.NextDouble() * SpawnArea.x * 2 - SpawnArea.x) + SpawnOffset.x,
            (float) (_rand.NextDouble() * SpawnArea.y * 2 - SpawnArea.y) + SpawnOffset.y
        );
        for (var i = 0; i < BannedSpawnAreas.Count; i++)
        {
            Vector2 center = i < BannedSpawnOffsets.Count ? BannedSpawnOffsets[i] : Vector2.zero,
                area = BannedSpawnAreas[i];
            if (center.x - area.x < v.x && v.x < center.x + area.x && center.y - area.y < v.y &&
                v.y < center.y + area.y)
                return GetRandomSpawnPoint();
        }
        return v;
    }

    private Vector2 GetSecuritySpawn() => SecuritySpawns[_rand.Next(SecuritySpawns.Count)];

    public void SpawnSecurity(GameObject go)
    {
        var sec = Instantiate(Security, GetSecuritySpawn(), Quaternion.identity);
        sec.transform.parent = transform;
        sec.GetComponent<Security>()?.SetTarget(go);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(SpawnOffset, SpawnArea*2);
        Gizmos.color = Color.red;
        for (var i = 0; i < BannedSpawnAreas.Count; i++)
            try
            {
                Gizmos.DrawCube(BannedSpawnOffsets[i], BannedSpawnAreas[i]*2);
            }
            catch (Exception)
            {
                Gizmos.DrawCube(Vector2.zero, BannedSpawnAreas[i]*2);
            }
        Gizmos.color = Color.magenta;
        foreach (var p in SecuritySpawns)
            Gizmos.DrawSphere(p, .1f);
    }
}
