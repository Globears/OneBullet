using System;
using UnityEngine;

public class Target : GridObject
{
    void Start()
    {
        type = GridObjectType.Monster;
        transform.position = world.GetWorldPosition(x, y);
    }

}
