using UnityEngine;

public class Wall : GridObject
{
    World world;
    PlayerController player;

    void Start()
    {
        world = World.instance;
        player = PlayerController.instance;
        EventManager.OnBulletFlyFinish += OnBulletFlyFinish;
    }

    public void OnBulletFlyFinish(int fromX, int fromY, int newX, int newY, Bullet bullet)
    {
        if (this.x == newX && this.y == newY)
        {
            EventManager.BulletHit(x, y, bullet);
            OnHit(bullet);
        }
    }

    public void OnHit(Bullet bullet)
    {
        bullet.SelfDestroy();
    }
}
