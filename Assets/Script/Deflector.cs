using System.Collections;
using UnityEngine;

public class Deflector : GridObject
{
    World world;
    PlayerController player;
    Bullet bullet;

    void Start()
    {
        world = World.instance;
        player = PlayerController.instance;
        bullet = Bullet.instance;

        
    }

    public void OnFire()
    {
        
    }
}
