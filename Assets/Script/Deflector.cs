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

    public void OnFire(Bullet bullet)
    {
        this.bullet = bullet;
        bullet.FlyingStart += OnBulletFlyingStart;
        bullet.FlyingFinish += OnBulletFlyingFinish;
        Debug.Log("Fire");
    }

    public void OnGoingTobeHit(Bullet bullet)
    {

    }

    public void OnHit(Bullet bullet)
    {
        Debug.Log("Hit");
        int newDx = -bullet.dy;
        int newDy = bullet.dx;
        bullet.SetDirection(newDx, newDy);
    }

    public void OnBulletFlyingStart(int fromX, int fromY, int newX, int newY, Bullet bullet)
    {
        if (newX == x && newY == y)
        {
            OnGoingTobeHit(bullet);
        }
    }

    public void OnBulletFlyingFinish(int fromX, int fromY, int newX, int newY, Bullet bullet)
    {
        if (newX == x && newY == y)
        {
            OnHit(bullet);
        }
    }
}
