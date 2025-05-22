using System.Collections;
using UnityEngine;

public class Deflector : GridObject
{
    World world;
    PlayerController player;
    public Bullet bullet;

    void Start()
    {
        world = World.instance;
        player = PlayerController.instance;
        

        player.Fire += OnFire;
        
    }

    public void OnFire()
    {
        bullet = Bullet.instance;
        bullet.FlyingStart += OnBulletFlyingStart;
        bullet.FlyingFinish += OnBulletFlyingFinish;
        Debug.Log("Fire");
    }

    public void OnGoingTobeHit()
    {

    }

    public void OnHit()
    {

    }

    public void OnBulletFlyingStart(int fromX, int fromY, int newX, int newY)
    {
        if (newX == x && newY == y)
        {
            OnGoingTobeHit();
        }
    }

    public void OnBulletFlyingFinish(int fromX, int fromY, int newX, int newY)
    {
        if (newX == x && newY == y)
        {
            OnHit();
        }
    }
}
