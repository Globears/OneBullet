using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    World world;
    public int x, y;
    public int dx, dy;
    public float speed = 6f; //unit per second


    public void Fly()
    {
        StartCoroutine(FlyCoroutine());
    }
    IEnumerator FlyCoroutine()
    {
        int newX = x + dx;
        int newY = y + dy;
        while(true)
        {
            Vector3 targetPosition = world.CellToWorldPosition(newX, newY);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                break;
            }
            yield return null;
        }
        if (world.GetGridObjectAt(newX, newY).type == GridObjectType.Wall)
        {
            Destroy(gameObject);
            yield break;
        }

        transform.position = world.CellToWorldPosition(newX, newY);
        x = newX;
        y = newY;

        StartCoroutine(FlyCoroutine());
    }




    void Start()
    {
        world = World.instance;
        Fly();
    }
}
