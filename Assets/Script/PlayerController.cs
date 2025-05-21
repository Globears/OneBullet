using UnityEngine;

public class PlayerController : GridObject
{
    public delegate void FireHandler(Bullet bullet);
    public event FireHandler OnFire;
    public GameObject bulletPrefab;
    public int dx = -1, dy = -1;

    void Fire()
    {
        Bullet bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
        bullet.dx = dx;
        bullet.dy = dy;
        bullet.x = x;
        bullet.y = y;
        OnFire?.Invoke(bullet);
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(0, 1);
            dy = 1;
            dx = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(0, -1);
            dy = -1;
            dx = 0;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Move(-1, 0);
            dx = -1;
            dy = 0;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(1, 0);
            dx = 1;
            dy = 0;
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }
}
