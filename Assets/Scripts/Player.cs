using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movable
{
    private bool _npc = true;
    private void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");
        Vector2 dir = new(hor, ver);
        if (_npc)
        {
            if (!(dir.magnitude > 0.1)) return;
            Destroy(GetComponent<NPC>());
            _npc = false;
        }
        if (dir.magnitude < 0.1)
            StopMove();
        else
            SetDirection(dir);
    }
}
