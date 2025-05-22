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

    public delegate void MovingHandler(int fromX, int fromY, int newX, int newY);
    public event MovingHandler MovingStart, MovingFinish;

    IEnumerator MoveCoroutine(int dx, int dy)
    {
        isAnimatingMove = true;
        this.dx = dx;
        this.dy = dy;
        int newX = x + dx;
        int newY = y + dy;
        int fromX = x;
        int fromY = y;

        if (world.GetGridObjectAt(newX, newY).type != GridObjectType.None
        && world.GetGridObjectAt(newX, newY).type != GridObjectType.Ground) yield break;

        MovingStart?.Invoke(fromX, fromY, newX, newY);

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
        x = newX;
        y = newY;
        MovingFinish?.Invoke(fromX, fromY, newX, newY);
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Move(-1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.x = x;
            bullet.y = y;
            bullet.dx = dx;
            bullet.dy = dy;
        }
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
