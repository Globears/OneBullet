using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Awake()
    {
    }

    World world;
    TrailRenderer trailRenderer;
    public GameObject explodePrefab;
    public int x, y;
    public int dx, dy;
    public float speed = 6f; //unit per second




    public void SetDirection(int dx, int dy)
    {
        this.dx = dx;
        this.dy = dy;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dy, dx) * Mathf.Rad2Deg);
    }

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

        EventManager.BulletFlyStart(fromX, fromY, newX, newY, this);
        while (true)
        {
            Vector3 targetPosition = world.CellToWorldPosition(newX, newY);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)break;
            
            yield return null;
        }

        transform.position = world.CellToWorldPosition(newX, newY);
        x = newX;
        y = newY;
        EventManager.BulletFlyFinish(fromX, fromY, newX, newY, this);
        StartCoroutine(FlyCoroutine());
    }

    public void SelfDestroy()
    {
        EventManager.BulletDestroy(x, y, this);
        trailRenderer.transform.parent = this.transform.parent;
        Destroy(trailRenderer.gameObject, trailRenderer.time);
        
        Destroy(gameObject);
    }

    public void OnHit(int x, int y, Bullet bullet)
    {
        if (bullet != this) return;
        GameObject explode = Instantiate(explodePrefab);
        explode.transform.parent = transform.parent;
        explode.transform.position = transform.position;
        Destroy(explode, 1f);
    }


    void Start()
    {
        trailRenderer = transform.Find("Trail").GetComponent<TrailRenderer>();
        world = World.instance;
        EventManager.OnBulletHit += OnHit;
        Fly();
    }
}
