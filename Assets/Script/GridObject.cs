using UnityEngine;


public enum GridObjectType
{
    Player,
    Wall,
    Monster,
    Deflector,
    None,
}

public class GridObject : MonoBehaviour
{
    public GridObjectType type;
    public PlayerController player;
    public World world;
    public int x, y;
    public Bullet bullet;

    void Awake()
    {
        world = GameObject.Find("World").GetComponent<World>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (world == null)
        {
            Debug.LogError("World component not found!");
        }

    }

    public void Move(Vector3Int direction)
    {
        Move(direction.x, direction.y);
    }
    public void Move(int dx, int dy)
    {
        int newX = x + dx;
        int newY = y + dy;

        if (world.IsValidPosition(newX, newY))
        {
            x = newX;
            y = newY;
            transform.position = world.GetWorldPosition(x, y);
        }
    }
    public virtual void Hit()
    {

    }


}

