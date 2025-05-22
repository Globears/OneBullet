using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public World world = World.instance;
    public int x, y;
    public int dx, dy;

    IEnumerator Fly()
    {
        int newX = x + dx;
        int newY = y + dy;

        if (world.GetGridObjectAt(newX, newY).type == GridObjectType.Wall)
        {
            Destroy(gameObject);
            yield break;
        }

        yield return new WaitForSeconds(0.1f);
        transform.position = world.CellToWorldPosition(newX, newY);
        x = newX;
        y = newY;

        StartCoroutine(Fly());
    }

    void Start()
    {
        world = World.instance;

        StartCoroutine(Fly());
    }
}
