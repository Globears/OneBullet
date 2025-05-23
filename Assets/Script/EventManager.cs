using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void PlayerMovingHandler(int fromX, int fromY, int newX, int newY);
    public static event PlayerMovingHandler OnPlayerMovingStart, OnPlayerMovingFinish;
    public static void PlayerMovingStart(int fromX, int fromY, int newX, int newY)
    {
        OnPlayerMovingStart?.Invoke(fromX, fromY, newX, newY);
    }
    public static void PlayerMovingFinish(int fromX, int fromY, int newX, int newY)
    {
        OnPlayerMovingFinish?.Invoke(fromX, fromY, newX, newY);
    }
    public delegate void BulletFlyHandler(int fromX, int fromY, int newX, int newY, Bullet bullet);
    public static event BulletFlyHandler OnBulletFlyStart, OnBulletFlyFinish;

    public static void BulletFlyStart(int fromX, int fromY, int newX, int newY, Bullet bullet)
    {
        OnBulletFlyStart?.Invoke(fromX, fromY, newX, newY, bullet);
    }

    public static void BulletFlyFinish(int fromX, int fromY, int newX, int newY, Bullet bullet)
    {
        OnBulletFlyFinish?.Invoke(fromX, fromY, newX, newY, bullet);
    }

    public delegate void ShootingHandler(Bullet bullet);
    public static event ShootingHandler OnShooting;

    public static void Shooting(Bullet bullet)
    {
        OnShooting?.Invoke(bullet);
    }

    public delegate void BulletHitHandler(int x, int y, Bullet bullet);
    public static event BulletHitHandler OnBulletHit, OnBulletDestroy;

    public static void BulletHit(int x, int y, Bullet bullet)
    {
        OnBulletHit?.Invoke(x, y, bullet);
    }
    public static void BulletDestroy(int x, int y, Bullet bullet)
    {
        OnBulletDestroy?.Invoke(x, y, bullet);
    }
}
