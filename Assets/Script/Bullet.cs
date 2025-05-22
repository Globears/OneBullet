using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet instance;
    private void Awake()
    {
        instance = this;
    }

    World world;
    public int x, y;
    public int dx, dy;
    public float speed = 6f; //unit per second

    public delegate void FlyingHandler(int fromX, int fromY, int newX, int newY);
    public event FlyingHandler FlyingStart, FlyingFinish;


    public void Fly()
    {
        Debug.Log("Fly");
        StartCoroutine(FlyCoroutine());
    }
    IEnumerator FlyCoroutine()
    {
        int fromX = x;
        int fromY = y;
        int newX = x + dx;
        int newY = y + dy;

        FlyingStart?.Invoke(fromX, fromY, newX, newY);
        while (true)
        {
            Vector3 targetPosition = world.CellToWorldPosition(newX, newY);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)break;
            
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
        FlyingFinish?.Invoke(fromX, fromY, newX, newY);
        StartCoroutine(FlyCoroutine());
    }




    void Start()
    {
        world = World.instance;
        Fly();
    }
}
