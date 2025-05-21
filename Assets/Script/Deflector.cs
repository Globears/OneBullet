using UnityEngine;

public class Deflector : GridObject
{
    public override void Hit()
    {

    }
    void Start()
    {
        type = GridObjectType.Deflector;
        transform.position = world.GetWorldPosition(x, y);
    }
}
