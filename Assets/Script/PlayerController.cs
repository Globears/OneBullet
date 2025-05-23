using System.Collections;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR;

public class PlayerController : GridObject
{
    World world;
    public static PlayerController instance;
    public int dx, dy;
    public Bullet bulletPrefab;
    public float speed = 3f;
    public Animator animator;


    IEnumerator MoveCoroutine(int dx, int dy)
    {
        isAnimatingMove = true;
        this.dx = dx;
        this.dy = dy;
        int newX = x + dx;
        int newY = y + dy;
        int fromX = x;
        int fromY = y;

        EventManager.PlayerMovingStart(fromX, fromY, newX, newY);
        x = newX;
        y = newY;

        

        while (true)
        {
            Vector3 targetPosition = world.CellToWorldPosition(newX, newY);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                break;
            }
            yield return null;
        }

        
        transform.position = world.CellToWorldPosition(x, y);

        EventManager.PlayerMovingFinish(fromX, fromY, newX, newY);
        isAnimatingMove = false;
        yield return null;
    }
    bool isAnimatingMove = false;
    public void Move(int dx, int dy)
    {
        if (isAnimatingMove) return;
        StartCoroutine(MoveCoroutine(dx, dy));
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            EventManager.Shooting(bullet);
            bullet.x = x;
            bullet.y = y;
            bullet.dx = this.dx;
            bullet.dy = this.dy;
        }

        int dx = 0;
        int dy = 0;
        if (Input.GetKeyDown(KeyCode.W))
        {
            dy = 1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            dy = -1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            dx = -1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            dx = 1;
        }
        if (dx == 0 && dy == 0) return;
        int newX = x + dx;
        int newY = y + dy;
        if (world.GetGridObjectAt(newX, newY).type != GridObjectType.None
            && world.GetGridObjectAt(newX, newY).type != GridObjectType.Ground) return;
        if (isAnimatingMove) return;
        Move(dx, dy);

        
    }


    void Update()
    {
        HandleInput();
    }

    void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        world = World.instance;
    }
}
