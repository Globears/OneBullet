using UnityEngine;

public class TestEnemyAI_1 : GridObject
{
    World world;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        world = World.instance;
        EventManager.OnPlayerMovingStart += OnPlayerMovingStart;
        EventManager.OnPlayerMovingFinish += OnPlayerMovingFinish;
        EventManager.OnBulletFlyFinish += OnBulletFlyingFinish;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Move(int dx, int dy)
    {
        int newX = x + dx;
        int newY = y + dy;
        x = newX;
        y = newY;
        transform.position = world.CellToWorldPosition(x, y);
    }

    void OnPlayerMovingStart(int fromX, int fromY, int newX, int newY)
    {

    }

    void OnPlayerMovingFinish(int fromX, int fromY, int newX, int newY)
    {
        Move(Random.Range(-1, 2), Random.Range(-1, 2));
    }

    void OnHit(Bullet bullet)
    {
        EventManager.BulletHit(x, y, bullet);
    }

    void OnBulletFlyingFinish(int fromX, int fromY, int newX, int newY, Bullet bullet)
    {
        if (newX == x && newY == y)
        {
            OnHit(bullet);
        }
    }
}
