using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public World world;
    public int x, y;
    public int dx, dy;
    public float animatedSpeed;

    IEnumerator AnimatedFly(int newX, int newY)
    {
        Vector3 start = world.GetWorldPosition(x, y);
        Vector3 end = world.GetWorldPosition(newX, newY);
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * animatedSpeed;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public IEnumerator Fly()
    {

        int newX = x + dx;
        int newY = y + dy;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dy, dx) * Mathf.Rad2Deg);

        if (world.GetGridAt(newX, newY) == GridObjectType.Wall)
        {
            HitWall();
            yield break;
        }
        if (world.GetGridAt(newX, newY) == GridObjectType.Monster)
        {
            HitWall();
            yield break;
        }
        

        yield return StartCoroutine(AnimatedFly(newX, newY));
        x = newX;
        y = newY;

        if (world.GetGridAt(x, y) == GridObjectType.Deflector)
        {
            if (dx != 0)
            {
                dy = dx;
                dx = 0;
            }
            else
            {
                dx = -dy;
                dy = 0;
            }
        }


        StartCoroutine(Fly());
        Debug.Log("Bullet position: " + x + ", " + y);
    }
    public void HitWall()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
        StartCoroutine(Fly());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
