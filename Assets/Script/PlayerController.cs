using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR;

public class PlayerController : GridObject
{
    public int dx, dy;
    public Bullet bulletPrefab;
    public void Move(int dx, int dy)
    {
        this.dx = dx;
        this.dy = dy;
        int newX = x + dx;
        int newY = y + dy;

        if (world.GetGridObjectAt(newX, newY) == null || world.GetGridObjectAt(newX, newY).type == GridObjectType.Ground)
        {
            x = newX;
            y = newY;
            transform.position = world.CellToWorldPosition(x, y);
        }


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
}
